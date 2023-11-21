using INSN.Web.Portal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace INSN.Web.Portal.Controllers.Home
{
    public class EspecialidadesController : Controller
    {
        private readonly ILogger<EspecialidadesController> _logger;

        public EspecialidadesController(ILogger<EspecialidadesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Especialidades/Index.cshtml");
        }

        public IActionResult Cardiologia()
        {
            return View("~/Views/Home/Especialidades/Cardiologia.cshtml");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}