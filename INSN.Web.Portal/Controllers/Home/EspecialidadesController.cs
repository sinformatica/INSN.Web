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

        #region [Medicina]
        public IActionResult Cardiologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Cardiologia.cshtml");
        }

        public IActionResult AlergiaAsmaInmunologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/AlergiaAsmaInmunologia.cshtml");
        }
        
        public IActionResult Gastroenterologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Gastroenterologia.cshtml");
        }
        
        public IActionResult Dermatologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Dermatologia.cshtml");
        }

        public IActionResult Endocrinologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Endocrinologia.cshtml");
        }
        
        public IActionResult Hematologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Hematologia.cshtml");
        }

        public IActionResult Infectologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Infectologia.cshtml");
        }

        public IActionResult MedicinaAdolescente()
        {
            return View("~/Views/Home/Especialidades/Medicina/MedicinaAdolescente.cshtml");
        }
        
        public IActionResult MedicinaFisica()
        {
            return View("~/Views/Home/Especialidades/Medicina/MedicinaFisica.cshtml");
        }

        public IActionResult MedicinaPediatrica()
        {
            return View("~/Views/Home/Especialidades/Medicina/MedicinaPediatrica.cshtml");
        }

        public IActionResult Nefrologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Nefrologia.cshtml");
        }

        public IActionResult Neonatologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Neonatologia.cshtml");
        }

        public IActionResult Neumologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Neumologia.cshtml");
        }

        public IActionResult Neurologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Neurologia.cshtml");
        }

        public IActionResult Reumatologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Reumatologia.cshtml");
        }
        
        public IActionResult UnidadCuidadoPaliativos()
        {
            return View("~/Views/Home/Especialidades/Medicina/UnidadCuidadoPaliativos.cshtml");
        }
        #endregion


        #region [Medicina]
        public IActionResult CirugiaCabeza()
        {
            return View("~/Views/Home/Especialidades/Cirugia/CirugiaCabeza.cshtml");
        }

        public IActionResult CirugiaPediatrica()
        {
            return View("~/Views/Home/Especialidades/Cirugia/CirugiaPediatrica.cshtml");
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}