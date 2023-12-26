using INSN.Web.Common;
using INSN.Web.Models;
using INSN.Web.Portal.Services.Interfaces;
using INSN.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

namespace INSN.Web.Portal.Controllers
{
    public class SistemasController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly ISistemaProxy _proxy;

        /// <summary>
        /// Sistemas Controller
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public SistemasController(ISistemaProxy proxy,IWebHostEnvironment env)
        {
            _proxy = proxy;           
            _enviroment = env;
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

                // Realizar acciones con la información del token deserializado
                var response = await _proxy.SistemasPorUsuarioListar(new LoginUsuarioDtoRequest()
                {
                    Usuario = usuario
                });

                model.ListaSistema = response;
            }

            return View("~/Views/Usuario/Sistema.cshtml", model);
        }
    }
}
