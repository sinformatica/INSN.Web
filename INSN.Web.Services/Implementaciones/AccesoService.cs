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
using Azure;
using INSN.Web.Models.Response.Sistemas;
using INSN.Web.Models.Request.SegApp.Mantenimiento;

namespace INSN.Web.Services.Implementaciones
{
    /// <summary>
    /// Service Usuario
    /// </summary>
    public class AccesoService : IAccesoService
    {
        private readonly UserManager<INSNIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppConfiguration _configuration;
        private readonly ILogger<AccesoService> _logger;
        private readonly SegAppDbContext _segAppDbContext;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <param name="segAppDbContext"></param>
        public AccesoService(UserManager<INSNIdentityUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            IOptions<AppConfiguration> options,
                            ILogger<AccesoService> logger,
                            SegAppDbContext segAppDbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = options.Value;
            _roleManager = roleManager;
            _segAppDbContext = segAppDbContext;
        }

        /// <summary>
        /// Service: Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LoginDtoResponse> Login(LoginDtoRequest request)
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

                var fechaVencimiento = DateTime.Now.AddHours(6);
                string nombreCompleto = $"{identity.ApellidoPaterno} {identity.ApellidoMaterno} {identity.Nombres}";

                var claims = new List<Claim>
                {
                    new Claim("username", request.Usuario),
                    new Claim("name", nombreCompleto),
                    new Claim("FechaVencimiento", fechaVencimiento.ToString("yyyy-MM-dd HH:mm:ss")),
                    //new Claim(ClaimTypes.Expiration, fechaVencimiento.ToString("yyyy-MM-dd HH:mm:ss"))
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

        /// <summary>
        /// Service: Sistemas Por Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<SistemaDtoResponse>>> SistemasPorUsuarioListar(LoginUsuarioDtoRequest request)
        {
            var response = new BaseResponseGeneric<ICollection<SistemaDtoResponse>>();
            var ListaSistemas = new List<SistemaDtoResponse>();

            try
            {
                // Buscar el usuario por nombre
                var user = await _userManager.FindByNameAsync(request.Usuario);

                if (user == null)
                {
                    // Si el usuario no se encuentra, retornar lista vacía 
                  //  return response;
                }

                // Consulta para obtener los sistemas asociados al usuario
                var sistemasAsociados = await _segAppDbContext.INSNIdentityUsuarioRol
                    .Where(ur => ur.UserId == user.Id)
                    .Select(ur => ur.CodigoSistemaId)
                    .Distinct()
                    .ToListAsync();

                // Obtener los detalles de los sistemas asociados y convertirlos a SistemasDtoResponse
                foreach (var codigoSistemaId in sistemasAsociados)
                {
                    var sistema = await _segAppDbContext.INSNIdentitySistema
                        .Where(s => s.CodigoSistemaId == codigoSistemaId)
                        .FirstOrDefaultAsync();

                    if (sistema != null)
                    {
                        // Realizar la conversión de INSNIdentitySistema a SistemasDtoResponse 
                        var sistemaDto = new SistemaDtoResponse
                        {
                            CodigoSistemaId = sistema.CodigoSistemaId,
                            descripcion = sistema.descripcion,
                            url = sistema.url,
                            icono = sistema.icono
                        };

                        ListaSistemas.Add(sistemaDto);
                    }
                }

                response.Data = ListaSistemas;
                response.Success = true;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                _logger.LogCritical(ex, "Error al obtener sistemas para el usuario {Usuario}: {Message}", request.Usuario, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Service: Login Sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LoginDtoResponse> LoginSistema(LoginSistemaDtoRequest request)
        {
            var response = new LoginDtoResponse();

            try
            {
                var identity = await _userManager.FindByNameAsync(request.Usuario);

                var roles = await _segAppDbContext.INSNIdentityUsuarioRol
                        .Where(ur => ur.UserId == identity.Id && ur.CodigoSistemaId == request.CodigoSistemaId)
                        .Select(ur => ur.RoleId)
                        .ToListAsync();

                var fechaVencimiento = DateTime.Now.AddHours(6);
                string nombreCompleto = $"{identity.ApellidoPaterno} {identity.ApellidoMaterno} {identity.Nombres}";
                var roleName = await _roleManager.FindByIdAsync(roles.First());

                var claims = new List<Claim>
                {
                    new Claim("username", request.Usuario),
                    new Claim("name", identity.Nombres + " " + identity.ApellidoPaterno + " " + identity.ApellidoMaterno),
                    new Claim("RolId", roles.First()),
                    new Claim("rol", roleName?.Name),
                    new Claim("CodigoSistemaId", request.CodigoSistemaId.ToString()),
                    new Claim("FechaVencimiento", fechaVencimiento.ToString("yyyy-MM-dd HH:mm:ss")),
                    //new Claim(ClaimTypes.Expiration, fechaVencimiento.ToString("yyyy-MM-dd HH:mm:ss"))
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

        ///// <summary>
        ///// Service: Rol Insertar
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<BaseResponse> RolInsertar(string nombreRol)
        //{
        //    var response = new BaseResponse();

        //    try
        //    {
        //        if (!await _roleManager.RoleExistsAsync(nombreRol))
        //        {
        //            var nuevoRol = new IdentityRole(nombreRol);
        //            var resultado = await _roleManager.CreateAsync(nuevoRol);

        //            if (resultado.Succeeded)
        //            {
        //                // Rol creado exitosamente
        //                response.Success = true;
        //            }
        //            else
        //            {
        //                response.ErrorMessage = "Error al crear el rol";
        //                foreach (var error in resultado.Errors)
        //                {
        //                    response.ErrorMessage += $"{error.Description}, ";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            response.ErrorMessage = "El rol ya existe";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = "Error al crear el rol";
        //        _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        //    }

        //    return response;
        //}

        ///// <summary>
        ///// Service: Roles Usuario Asignar
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<BaseResponse> RolesUsuarioAsignar(UsuarioRolDtoRequest request)
        //{
        //    var response = new BaseResponse();

        //    try
        //    {
        //        var user = await _userManager.FindByIdAsync(request.UsuarioId);

        //        if (user is null)
        //        {
        //            response.ErrorMessage = "Usuario no encontrado";
        //            return response;
        //        }

        //        foreach (var roleName in request.ListaRoles)
        //        {
        //            var role = await _roleManager.FindByNameAsync(roleName.rol);

        //            if (role != null)
        //            {
        //                // Verificar si el usuario ya tiene el rol para este sistema
        //                var existingUserRole = await _segAppDbContext.INSNIdentityUsuarioRol
        //                    .FirstOrDefaultAsync(ur => ur.UserId == user.Id && ur.CodigoSistemaId == roleName.CodigoSistemaId && ur.RoleId == role.Id);

        //                if (existingUserRole != null)
        //                {
        //                    response.ErrorMessage = $"El usuario ya tiene el rol {roleName.rol} en este sistema";
        //                    return response;
        //                }

        //                // Eliminar roles anteriores del usuario en este sistema
        //                var userRolesInSystem = await _segAppDbContext.INSNIdentityUsuarioRol
        //                    .Where(ur => ur.UserId == user.Id && ur.CodigoSistemaId == roleName.CodigoSistemaId)
        //                    .ToListAsync();

        //                _segAppDbContext.INSNIdentityUsuarioRol.RemoveRange(userRolesInSystem);

        //                // Asignar el nuevo rol al usuario para este sistema
        //                var newUserRole = new INSNIdentityUsuarioRol
        //                {
        //                    UserId = user.Id,
        //                    RoleId = role.Id,
        //                    CodigoSistemaId = roleName.CodigoSistemaId
        //                };

        //                _segAppDbContext.INSNIdentityUsuarioRol.Add(newUserRole);
        //                await _segAppDbContext.SaveChangesAsync();
        //            }
        //            else
        //            {
        //                response.ErrorMessage = $"Rol {roleName.rol} no encontrado";
        //                return response;
        //            }
        //        }

        //        response.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = "Error al asignar roles al usuario";
        //        _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        //    }

        //    return response;
        //}
    }
}