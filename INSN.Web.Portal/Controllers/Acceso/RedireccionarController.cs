using INSN.Web.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using INSN.Web.Models.Request.Acceso;
using INSN.Web.Portal.Services.Interfaces.Acceso;

namespace INSN.Web.Portal.Controllers.Acceso
{
    /// <summary>
    /// RedireccionarController
    /// </summary>
    public class RedireccionarController : Controller
    {
        private readonly IRedireccionarProxy _proxy;
        private readonly ILogger<RedireccionarController> _logger;

        /// <summary>
        /// Redireccionar Controller
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="logger"></param>
        public RedireccionarController(IRedireccionarProxy proxy, ILogger<RedireccionarController> logger)
        {
            _proxy = proxy;    
            _logger = logger;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="p"></param>
        /// <param name="url"></param>
        /// <param name="ut"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(int p, string url, int ut)
        {
            string token = HttpContext.Session.GetString(Constantes.JwtToken) ?? string.Empty;

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    // Deserializar el token JWT
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var jwtToken = tokenHandler.ReadJwtToken(token);

                    // Acceder a los claims (información) dentro del token
                    var claims = jwtToken.Claims;

                    // Obtener el valor de un claim específico
                    var usuario = claims.FirstOrDefault(c => c.Type == "username")?.Value;

                    // Realizar acciones con la información del token deserializado
                    LoginSistemaDtoRequest modelo = new LoginSistemaDtoRequest();
                    modelo.Usuario = usuario?? string.Empty;
                    modelo.CodigoSistemaId = p;

                    var response = await _proxy.LoginSistema(modelo);

                    if (response.Success)
                    {
                        if (p == 1) // 1 = SegApp
                        {
                            // Leer token
                            tokenHandler = new JwtSecurityTokenHandler();
                            jwtToken = tokenHandler.ReadJwtToken(response.Token);

                            // Acceder a los claims (información) dentro del token
                            claims = jwtToken.Claims;

                            // Obtener el valor de un claim específico
                            var UsuarioId = claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
                            var Usuario = claims.FirstOrDefault(c => c.Type == "username")?.Value;
                            var NombreUsuario = claims.FirstOrDefault(c => c.Type == "name")?.Value;
                            var CodigSistemaIdUsuario = claims.FirstOrDefault(c => c.Type == "CodigoSistemaId")?.Value;
                            var NombreRolUsuario = claims.FirstOrDefault(c => c.Type == "rol")?.Value;
                            var FechaVencimiento = claims.FirstOrDefault(c => c.Type == "FechaVencimiento")?.Value;

                            // Guardar en constantes
                            HttpContext.Session.SetString(Constantes.JwtToken, response.Token);
                            HttpContext.Session.SetString(Constantes.UsuarioId, UsuarioId ?? string.Empty);
                            HttpContext.Session.SetString(Constantes.Usuario, Usuario ?? string.Empty);
                            HttpContext.Session.SetString(Constantes.NombreUsuario, NombreUsuario ?? string.Empty);
                            HttpContext.Session.SetString(Constantes.CodigoSistemaIdUsuario, CodigSistemaIdUsuario ?? string.Empty);
                            HttpContext.Session.SetString(Constantes.NombreRolUsuario, NombreRolUsuario ?? string.Empty);
                            HttpContext.Session.SetString(Constantes.FechaVencimiento, FechaVencimiento ?? string.Empty);

                            return RedirectToAction("Index", "Menu");
                        }
                        else
                        {
                            if (url == "#" || url == null)
                            {
                                return View("~/Views/SinPagina.cshtml");
                            }
                            else
                            {
                                if (ut == 1) // usar token = 1, o sea 'si'
                                    return Redirect($"{url}?token={response.Token}");
                                else
                                    return Redirect($"{url}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex, "Error al obtener el token {token} {Message}", token, ex.Message);
                    return RedirectToAction("AccesoDenegado", "Acceso");
                }
            }

            return RedirectToAction("Index", "Sistemas");
        }
    }
}