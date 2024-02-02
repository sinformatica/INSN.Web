using INSN.Web.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using INSN.Web.ViewModels.Exceptions;
using INSN.Web.ViewModels.SegApp;
using INSN.Web.Models.Request.Acceso;
using INSN.Web.Portal.Services.Interfaces.Acceso;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento;

namespace INSN.Web.Portal.Controllers.Acceso
{
    /// <summary>
    /// AccesoController
    /// </summary>
    public class AccesoController : Controller
    {
        private readonly IAccesoProxy _proxy;
        private readonly IUsuarioProxy _proxyUsuario;
        private readonly ILogger<AccesoController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="proxyUsuario"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="logger"></param>
        public AccesoController(IAccesoProxy proxy, IUsuarioProxy proxyUsuario, 
                IHttpContextAccessor httpContextAccessor, ILogger<AccesoController> logger)
        {
            _proxy = proxy;
            _proxyUsuario = proxyUsuario;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View("~/Views/Acceso/Login.cshtml");
        }

        /// <summary>
        /// Acceso Denegado
        /// </summary>
        /// <returns></returns>
        public IActionResult AccesoDenegado()
        {
            return View("~/Views/AccesoDenegado.cshtml");
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginDtoRequest modelo)
        {
            try
            {
                var response = await _proxy.Login(modelo);
                if (response.Success)
                {
                    // Hacer el proceso de Login
                    var handler = new JwtSecurityTokenHandler();
                    var jwt = handler.ReadJwtToken(response.Token);

                    // Leer los Claims
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                    identity.AddClaims(jwt.Claims);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    // Guardamos la sesion
                    HttpContext.Session.SetString(Constantes.JwtToken, response.Token);
                    return RedirectToAction("Index", "Acceso");
                }

                ModelState.AddModelError("ErrorMessage", response.ErrorMessage ?? "");
                return View(modelo);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ErrorMessage", ex.Message);
                return View(modelo);
            }
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(Constantes.JwtToken, string.Empty);

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            string token = HttpContext.Session.GetString(Constantes.JwtToken);
            SistemasViewModel model = new SistemasViewModel();

            if (token != null)
            {
                // Deserializar el token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                // Acceder a los claims (información) dentro del token
                var claims = jwtToken.Claims;

                // Obtener el valor de un claim específico
                var UsuarioId = claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
                var Usuario = claims.FirstOrDefault(c => c.Type == "username")?.Value;
                string NombreUsuario = claims.FirstOrDefault(c => c.Type == "name")?.Value;

                _httpContextAccessor.HttpContext.Session.SetString(Constantes.UsuarioId, UsuarioId);
                _httpContextAccessor.HttpContext.Session.SetString(Constantes.Usuario, Usuario);
                _httpContextAccessor.HttpContext.Session.SetString(Constantes.NombreUsuario, NombreUsuario);

                // Realizar acciones con la información del token deserializado
                var response = await _proxy.SistemasPorUsuarioListar(new LoginUsuarioDtoRequest()
                {
                    Usuario = Usuario
                });

                model.UsuarioId = UsuarioId;
                model.ListaSistema = response;
                model.Usuario = Usuario;
            }

            return View("~/Views/Acceso/Sistema.cshtml", model);
        }

        /// <summary>
        /// Usuario Actualizar Clave desde el menú principal
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IActionResult> UsuarioActualizarClave(SistemasViewModel request)
        {
            try
            {
                var result = await _proxy.SistemasPorUsuarioListar(new LoginUsuarioDtoRequest()
                {
                    Usuario = request.Usuario
                });

                request.ListaSistema = result;

                var response = _proxyUsuario.UsuarioBuscarId(request.UsuarioId);

                if (response is null)
                {
                    ModelState.AddModelError("ID", "No se encontro el registro");
                    return View();
                }

                if (string.IsNullOrWhiteSpace(request.Clave)) throw new ModelException(nameof(request.Clave), "Campo requerido: Contraseña");

                if (string.IsNullOrWhiteSpace(request.ConfirmaClave))
                {
                    throw new ModelException(nameof(request.ConfirmaClave), "Campo requerido: Confirmar contraseña");
                }
                else
                {
                    if (request.Clave != request.ConfirmaClave) throw new ModelException(nameof(request.ConfirmaClave), "Contraseñas no coinciden");
                }

                var dtoRequest = new UsuarioDtoRequest
                {
                    Id = request.UsuarioId,
                    Password = request.Clave,
                    ConfirmarPassword = request.Clave,
                    #region [Base Update]
                    EstadoRegistro = 1,
                    FechaCreacion = response.Result.FechaCreacion,
                    UsuarioCreacion = response.Result.UsuarioCreacion,
                    TerminalCreacion = response.Result.TerminalCreacion,
                    TerminalModificacion = Environment.MachineName,
                    UsuarioModificacion = request.Usuario,
                    FechaModificacion = DateTime.Now
                    #endregion
                };

                await _proxyUsuario.UsuarioActualizarClave(dtoRequest);

                #region[Controles de Codigo/Controller]
                TempData["CodigoMensaje"] = 1;
                TempData["Mensaje"] = "Contraseña actualizada correctamente";
                TempData["Metodo"] = "Index";
                TempData["Controlador"] = "Acceso";
                #endregion

                return RedirectToAction("Index", "Acceso");
            }
            catch (ModelException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                _logger.LogError(ex, "Validación de registro {Message}", ex.Message);
                ViewBag.ShowModal = true;
                return View("~/Views/Acceso/Sistema.cshtml", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Modificación de Usuario {Message}", ex.Message);
                TempData["CodigoMensaje"] = -1;
                TempData["Mensaje"] = ex.Message;
                return View("~/Views/Acceso/Sistema.cshtml", request);
            }
        }
    }
}