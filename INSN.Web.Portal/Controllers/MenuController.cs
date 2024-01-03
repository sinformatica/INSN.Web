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
                bool b = false;

                if (claims is not null)
                {
                    if (claims.Any()) b = true;
                }

                if (b)
                {
                    // Obtener el valor de un claim específico
                    model.Usuario = claims.FirstOrDefault(c => c.Type == "username")?.Value ?? string.Empty;
                    model.Nombre = claims.FirstOrDefault(c => c.Type == "name")?.Value ?? string.Empty;
                    string RolId = claims.FirstOrDefault(c => c.Type == "RolId")?.Value ?? string.Empty;
                    string CodigoSistemaId = claims.FirstOrDefault(c => c.Type == "CodigoSistemaId")?.Value ?? string.Empty;
                    string FechaVencimiento = claims.FirstOrDefault(c => c.Type == "FechaVencimiento")?.Value ?? string.Empty;

                    if (DateTime.Now <= DateTime.Parse(FechaVencimiento))
                    {
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
                    else
                    {
                        return View("~/Views/Acceso/Login.cshtml");
                    }  
                }
                else
                {
                    return View("~/Views/Acceso/Login.cshtml");
                }      
            }
            else
            {
                return View("~/Views/Acceso/Login.cshtml");
            }

            return View("~/Views/SegApp/Index.cshtml", model);
        }
    }
}