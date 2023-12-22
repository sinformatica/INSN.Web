using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers
{
    public class SistemasController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/User/Sistemas.cshtml");
        }

    //    public async Task<IActionResult> Index(FarmaciaViewModel model)
    //{
    //    var response = await _proxy.FarmaciaListar(new FarmaciaDtoRequest()
    //    {
    //        Estado = model.EstadoSeleccionado,
    //        Descripcion = model.Descripcion,
    //        EstadoRegistro = 1
    //    });

    //    model.Farmacias = response;

    //    return View("~/Views/Mantenimiento/Farmacia/Index.cshtml", model);
    //}
    }
}
