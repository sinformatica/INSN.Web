using INSN.Web.Common;
using INSN.Web.Models.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security;
using System.Text;
using INSN.Web.DataAccess;
using Microsoft.EntityFrameworkCore;
using INSN.Web.Models.Response.Sistemas;
using INSN.Web.DataAccess.Acceso;
using INSN.Web.Models.Response.Acceso;
using INSN.Web.Models.Request.Acceso;
using INSN.Web.Services.Interfaces.Acceso;

namespace INSN.Web.Services.Implementaciones.Acceso
{
    /// <summary>
    /// AccesoService
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

                if (identity is null || identity.EstadoRegistro == 0)
                {
                    throw new SecurityException("Usuario no existe");
                }

                if (identity.Estado != "A")
                {
                    throw new SecurityException("Usuario no está activo");
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
                    new Claim("UserId", identity.Id),
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
                }

                // Consulta para obtener los sistemas asociados al usuario
                var sistemasAsociados = await _segAppDbContext.INSNIdentityUsuarioRol
                    .Where(ur => user != null && ur.UserId == user.Id && ur.Estado == "A" && ur.EstadoRegistro == 1)
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
                            Url = sistema.url,
                            Icono = sistema.icono,
                            Target = sistema.Target,
                            UsarToken = sistema.UsarToken
                        };

                        ListaSistemas.Add(sistemaDto);
                    }
                }

                response.Data = ListaSistemas;
                response.Success = true;
            }
            catch (Exception ex)
            {
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
                              .Where(ur => identity != null && ur.UserId == identity.Id
                                  && ur.CodigoSistemaId == request.CodigoSistemaId && ur.Estado == "A"
                                  && ur.EstadoRegistro == 1)
                              .Select(ur => ur.RoleId)
                              .ToListAsync();

                var fechaVencimiento = DateTime.Now.AddHours(6);

                string apellidoPaterno = identity?.ApellidoPaterno ?? string.Empty;
                string apellidoMaterno = identity?.ApellidoMaterno ?? string.Empty;
                string nombres = identity?.Nombres ?? string.Empty;
                string nombreCompleto = $"{apellidoPaterno} {apellidoMaterno} {nombres}";

                var roleName = await _roleManager.FindByIdAsync(roles.First());

                var claims = new List<Claim>
                {
                    new Claim("UserId", identity?.Id ?? string.Empty),
                    new Claim("username", request.Usuario),
                    new Claim("name", $"{identity?.Nombres ?? string.Empty} {identity?.ApellidoPaterno ?? string.Empty} {identity?.ApellidoMaterno ?? string.Empty}"),
                    new Claim("RolId", roles.First()),
                    new Claim("rol", roleName?.Name ?? ""),
                    new Claim("CodigoSistemaId", request.CodigoSistemaId.ToString()),
                    new Claim("FechaVencimiento", fechaVencimiento.ToString("yyyy-MM-dd HH:mm:ss")),
                    new Claim(ClaimTypes.Role, roleName?.Name ??""),
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
    }
}