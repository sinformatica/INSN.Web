using INSN.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers
{
    public class ExcepcionesController : Controller
    {
        public IActionResult Index(ExcepcionesViewModel model)
        {
            if (model.Code == "401")
            {
                model.mensaje = "Acceso denegado";
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }

            return View("~/Views/Excepciones.cshtml", model);
        }
    }
}
