using INSN.Web.Common;
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
using Microsoft.EntityFrameworkCore;
using INSN.Web.Models.Request.SegApp;

namespace INSN.Web.Services.Implementaciones
{
    public class UserService : IUserService
    {
        private readonly UserManager<INSNIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppConfiguration _configuration;
        private readonly ILogger<UserService> _logger;
        private readonly SegAppDbContext _segAppDbContext;

        public UserService(UserManager<INSNIdentityUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            IOptions<AppConfiguration> options,
                            ILogger<UserService> logger,
                            SegAppDbContext segAppDbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = options.Value;
            _roleManager = roleManager;
            _segAppDbContext = segAppDbContext;
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
                string nombreCompleto = $"{identity.ApellidoPaterno} {identity.ApellidoMaterno} {identity.Nombres}";

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, nombreCompleto),
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
                response.NombresCompletos = nombreCompleto;
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

        public async Task<BaseResponse> RegistrarUsuarioAsync(UsuarioDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var user = new INSNIdentityUser
                {
                    Nombres = request.Nombres,
                    ApellidoPaterno = request.ApellidoPaterno,
                    ApellidoMaterno = request.ApellidoMaterno,
                    servicio = request.Servicio,
                    TipoDocumentoIdentidadId = request.TipoDocumentoIdentidadId,
                    UserName = request.Usuario,
                    Email = request.Email,
                    PhoneNumber = request.Telefono,
                    Telefono2 = request.Telefono2,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    user = await _userManager.FindByEmailAsync(user.Email);
                    if (user is not null)
                    {
                        response.Data = user.Id; // Establecer el ID del usuario en la respuesta
                    }
                }
                else
                {
                    var sb = new StringBuilder();

                    foreach (var error in result.Errors)
                    {
                        sb.Append($"{error.Description}, ");
                    }

                    response.ErrorMessage = sb.ToString();
                    sb.Clear(); // Liberar la memoria
                }

                response.Success = result.Succeeded;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al registrar";
                _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }


        //public async Task<BaseResponse> RegistrarUsuarioAsync(UsuarioDtoRequest request)
        //{
        //    var response = new BaseResponse();

        //    try
        //    {
        //        var user = new INSNIdentityUser
        //        {
        //            Nombres = request.Nombres,
        //            ApellidoPaterno = request.ApellidoPaterno,
        //            ApellidoMaterno = request.ApellidoMaterno,
        //            servicio = request.Servicio,
        //            TipoDocumentoIdentidadId = request.TipoDocumentoIdentidadId,
        //            UserName = request.Usuario,
        //            Email = request.Email,
        //            PhoneNumber = request.Telefono,
        //            Telefono2 = request.Telefono2,
        //            EmailConfirmed = true
        //        };

        //        var result = await _userManager.CreateAsync(user, request.Password);

        //        if (result.Succeeded)
        //        {
        //            // Esto me asegura que el usuario se creó correctamente
        //            user = await _userManager.FindByEmailAsync(user.Email);
        //            if (user is not null)
        //            {

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

        public async Task<BaseResponse> RegistrarRolAsync(string nombreRol)
        {
            var response = new BaseResponse();

            try
            {
                if (!await _roleManager.RoleExistsAsync(nombreRol))
                {
                    var nuevoRol = new IdentityRole(nombreRol);
                    var resultado = await _roleManager.CreateAsync(nuevoRol);

                    if (resultado.Succeeded)
                    {
                        // Rol creado exitosamente
                        response.Success = true;
                    }
                    else
                    {
                        response.ErrorMessage = "Error al crear el rol";
                        foreach (var error in resultado.Errors)
                        {
                            response.ErrorMessage += $"{error.Description}, ";
                        }
                    }
                }
                else
                {
                    response.ErrorMessage = "El rol ya existe";
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al crear el rol";
                _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse> AsignarRolesUsuarioAsync(UsuarioRolDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                using (var transaction = _segAppDbContext.Database.BeginTransaction())
                {
                    var user = await _userManager.FindByIdAsync(request.UsuarioId);

                    if (user is null)
                    {
                        response.ErrorMessage = "Usuario no encontrado";
                        return response;
                    }

                    var existingRoles = await _userManager.GetRolesAsync(user);

                    foreach (var roleName in request.roles)
                    {
                        if (!existingRoles.Contains(roleName))
                        {
                            var role = await _roleManager.FindByNameAsync(roleName);

                            if (role != null)
                            {
                                var result = await _userManager.AddToRoleAsync(user, role.Name);

                                if (!result.Succeeded)
                                {
                                    response.ErrorMessage = $"Error al asignar el rol {role.Name} al usuario";
                                    // Manejar el error si falla al asignar el rol
                                    transaction.Rollback(); // Deshacer la transacción
                                    return response;
                                }
                            }
                            else
                            {
                                response.ErrorMessage = $"Rol {roleName} no encontrado";
                                // Manejar el caso cuando el rol no existe en el sistema
                                transaction.Rollback(); // Deshacer la transacción
                                return response;
                            }
                        }
                        //else
                        //{
                        //    // El usuario ya tiene el rol, puedes manejar este caso si es necesario
                        //}
                    }

                    await transaction.CommitAsync(); // Confirmar la transacción
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al asignar roles al usuario";
                _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }
    }
}
