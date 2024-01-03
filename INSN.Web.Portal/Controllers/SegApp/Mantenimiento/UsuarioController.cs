using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.SegApp.Usuario
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/SegApp/Usuario/Index.cshtml");
        }
    }
}
