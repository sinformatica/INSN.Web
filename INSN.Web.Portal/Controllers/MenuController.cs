using INSN.Web.Common;
using INSN.Web.Models;
using INSN.Web.Models.Request.Sistema;
using INSN.Web.Portal.Services.Interfaces;
using INSN.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace INSN.Web.Portal.Controllers
{
    public class MenuController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly IMenuProxy _proxy;

        /// <summary>
        /// Menu Controller
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public MenuController(IMenuProxy proxy, IWebHostEnvironment env)
        {
            _proxy = proxy;
            _enviroment = env;
        }

        public async Task<IActionResult> Index()
        {
            string token = HttpContext.Session.GetString(Constantes.JwtToken);
            SeccionViewModel model = new SeccionViewModel();

            if (token != null)
            {
                // Deserializar el token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                // Acceder a los claims (información) dentro del token
                var claims = jwtToken.Claims;

                // Obtener el valor de un claim específico
                var CodigoSistemaId = claims.FirstOrDefault(c => c.Type == "CodigoSistemaId")?.Value;
                var RolId = claims.FirstOrDefault(c => c.Type == "RolId")?.Value;

                // Realizar acciones con la información del token deserializado
                var response = await _proxy.SeccionListar(new SeccionDtoRequest()
                {
                    CodigoSistemaId = int.Parse(CodigoSistemaId),
                    RolId = RolId
                });

                model.SeccionLista = response;

                foreach (var item in model.SeccionLista)
                {
                    var responseModulo = await _proxy.ModuloListar(new ModuloDtoRequest()
                    {
                        CodigoSeccionId = int.Parse(item.CodigoSeccionId.ToString()),
                        RolId = RolId
                    });

                    // Asignar la lista de módulos obtenida
                    item.ModuloLista = responseModulo; 
                }        
            }

            return View("~/Views/SegApp/Index.cshtml", model);
        }
    }
}