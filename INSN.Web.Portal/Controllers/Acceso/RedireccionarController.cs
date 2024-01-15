using INSN.Web.Common;
using INSN.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using INSN.Web.Models.Request.Acceso;
using INSN.Web.Portal.Services.Interfaces.Acceso;

namespace INSN.Web.Portal.Controllers.Acceso
{
    public class RedireccionarController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly IRedireccionarProxy _proxy;

        /// <summary>
        /// Redireccionar Controller
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public RedireccionarController(IRedireccionarProxy proxy, IWebHostEnvironment env)
        {
            _proxy = proxy;
            _enviroment = env;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        /// 
        public async Task<IActionResult> Index(int p, string url, int ut)
        {
            string token = HttpContext.Session.GetString(Constantes.JwtToken);
            //SistemasViewModel model = new SistemasViewModel();

            if (token != null)
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
                modelo.Usuario = usuario;
                modelo.CodigoSistemaId = p;

                var response = await _proxy.LoginSistema(modelo);

                if (response.Success)
                {
                    if (p == 1) // SegApp
                    {
                        // Leer token
                        var handler = new JwtSecurityTokenHandler();
                        var jwt = handler.ReadJwtToken(response.Token);

                        // Leer los Claims
                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                        identity.AddClaims(jwt.Claims);

                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        // Guardar token
                        HttpContext.Session.SetString(Constantes.JwtToken, response.Token);

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

            return RedirectToAction("Index", "Sistemas");
        }
    }
}
