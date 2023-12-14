﻿using INSN.Web.Common;
using INSN.Web.Models.Response;
using INSN.Web.Models;
using INSN.Web.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.DataAccess;

namespace INSN.Web.Services.Implementaciones
{
    public class UserService : IUserService
    {
        private readonly UserManager<INSNIdentityUser> _userManager;
        private readonly AppConfiguration _configuration;
        private readonly ILogger<UserService> _logger;

        public UserService(UserManager<INSNIdentityUser> userManager,
                            IOptions<AppConfiguration> options,
                            ILogger<UserService> logger)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = options.Value;
        }

        public async Task<LoginDtoResponse> LoginAsync(LoginDtoRequest request)
        {
            var response = new LoginDtoResponse();

            try
            {
                var identity = await _userManager.FindByNameAsync(request.Usuario);

                if (identity is null)
                {
                    throw new SecurityException("Usuario no existe");
                }

                if (await _userManager.IsLockedOutAsync(identity))
                {
                    throw new SecurityException($"Demasiados intentos fallidos para el usuario {request.Usuario}");
                }

                var result = await _userManager.CheckPasswordAsync(identity, request.Password);

                if (!result)
                {
                    response.ErrorMessage = "Clave incorrecta";
                    _logger.LogWarning("Error de autenticación para el usuario {Usuario}", request.Usuario);
                    await _userManager.AccessFailedAsync(identity); // Aumenta el contador de claves erroneas

                    return response;
                }

                var roles = await _userManager.GetRolesAsync(identity);
                var fechaVencimiento = DateTime.Now.AddHours(6);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.name, identity.Nombres),
                    new Claim(ClaimTypes.Role, roles.First()),
                    new Claim(ClaimTypes.Expiration, fechaVencimiento.ToString("yyyy-MM-dd HH:mm:ss"))
                };

                // Creacion del JWT
                var llaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Jwt.SecretKey));
                var credenciales = new SigningCredentials(llaveSimetrica, SecurityAlgorithms.HmacSha256);
                var header = new JwtHeader(credenciales);

                var payload = new JwtPayload(issuer: _configuration.Jwt.Emisor,
                    audience: _configuration.Jwt.Audiencia,
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: fechaVencimiento);

                var token = new JwtSecurityToken(header, payload);
                response.Token = new JwtSecurityTokenHandler().WriteToken(token);
                response.NombresCompletos = identity.NombreCompleto;
                response.Success = true;
            }
            catch (SecurityException ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogWarning(ex, "{Message}", ex.Message);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al autenticar";
                _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        //public async Task<BaseResponse> RegisterAsync(RegisterDtoRequest request)
        //{
        //    var response = new BaseResponse();

        //    try
        //    {
        //        var user = new GalaxyIdentityUser
        //        {
        //            NombreCompleto = request.NombreCompleto,
        //            UserName = request.Usuario,
        //            Email = request.Email,
        //            PhoneNumber = request.Telefono,
        //            EmailConfirmed = true
        //        };

        //        var result = await _userManager.CreateAsync(user, request.Password);

        //        if (result.Succeeded)
        //        {
        //            // Esto me asegura que el usuario se creó correctamente
        //            user = await _userManager.FindByEmailAsync(user.Email);
        //            if (user is not null)
        //            {
        //                await _userManager.AddToRoleAsync(user, Constantes.RolAlumno);

        //                // Aqui se pueden agregar otras acciones, tales como registrar en la tabla alumnos
        //                // enviar un email
        //            }
        //        }
        //        else
        //        {
        //            var sb = new StringBuilder();

        //            foreach (var error in result.Errors)
        //            {
        //                sb.Append($"{error.Description}, ");
        //            }

        //            response.ErrorMessage = sb.ToString();
        //            sb.Clear(); // Liberar la memoria
        //        }

        //        response.Success = result.Succeeded;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = "Error al registrar";
        //        _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        //    }

        //    return response;
        //}
    }
}
