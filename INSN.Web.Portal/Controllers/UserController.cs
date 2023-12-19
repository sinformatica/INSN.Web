using INSN.Web.Common;
using INSN.Web.Models;
using INSN.Web.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace INSN.Web.Portal.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserProxy _proxy;

        public UserController(IUserProxy proxy)
        {
            _proxy = proxy;
        }

        public IActionResult Login()
        {
            return View("~/Views/User/login.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("ErrorMessage", response.ErrorMessage ?? "Error");
                return View(modelo);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ErrorMessage", ex.Message);
                return View(modelo);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(Constantes.JwtToken, string.Empty);

            return RedirectToAction("Index", "Home");
        }
    }
}
