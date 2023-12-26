using INSN.Web.Models;
using INSN.Web.Portal.Services.Interfaces;
using INSN.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers
{
    public class SistemasController : Controller
    {
        private readonly ISistemasProxy _proxy;

        public IActionResult Index()
        {
            return View("~/Views/User/Sistemas.cshtml");
        }

        //public async Task<IActionResult> Index(LoginViewModel model)
        //{
        //    var response = await _proxy.ListarSistemasPorUsuario(new LoginUsuarioDtoRequest()
        //    {
        //        Usuario = model.Usuario
        //    });

        //    return View("~/Views/User/Sistemas.cshtml", model);
        //}
    }
}
