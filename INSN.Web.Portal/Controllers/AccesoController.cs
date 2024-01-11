using INSN.Web.Common;
using INSN.Web.Models;
using INSN.Web.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using INSN.Web.ViewModels.Exceptions;
using INSN.Web.ViewModels;

namespace INSN.Web.Portal.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IAccesoProxy _proxy;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy"></param>
        public AccesoController(IAccesoProxy proxy, IHttpContextAccessor httpContextAccessor)
        {
            _proxy = proxy;
            _httpContextAccessor = httpContextAccessor;
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
        /// Login
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
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
                var usuario = claims.FirstOrDefault(c => c.Type == "username")?.Value;
                string NombreUsuario = claims.FirstOrDefault(c => c.Type == "name")?.Value;
                _httpContextAccessor.HttpContext.Session.SetString(Constantes.NombreUsuario, NombreUsuario);

                // Realizar acciones con la información del token deserializado
                var response = await _proxy.SistemasPorUsuarioListar(new LoginUsuarioDtoRequest()
                {
                    Usuario = usuario
                });

                model.ListaSistema = response;
            }

            return View("~/Views/Acceso/Sistema.cshtml", model);
        }
    }
}
