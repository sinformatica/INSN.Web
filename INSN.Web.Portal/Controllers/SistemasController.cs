using INSN.Web.Models;
using INSN.Web.Portal.Services.Interfaces;
using INSN.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers
{
    public class SistemasController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly ISistemasProxy _proxy;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="env"></param>
        public SistemasController(ISistemasProxy proxy,IWebHostEnvironment env)
        {
            _proxy = proxy;           
            _enviroment = env;
        }

        public async Task<IActionResult> Index(SistemasViewModel model)
        {
            var response = await _proxy.ListarSistemasPorUsuario(new LoginUsuarioDtoRequest()
            {
                Usuario = model.Usuario
            });

            model.ListaSistema = response;

            return View("~/Views/User/Sistemas.cshtml", model);
        }
    }
}
