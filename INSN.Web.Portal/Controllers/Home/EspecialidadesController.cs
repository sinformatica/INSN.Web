using INSN.Web.Portal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace INSN.Web.Portal.Controllers.Home
{
    /// <summary>
    /// Controlador Especialidades
    /// </summary>
    public class EspecialidadesController : Controller
    {
        private readonly ILogger<EspecialidadesController> _logger;

        public EspecialidadesController(ILogger<EspecialidadesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View("~/Views/Home/Especialidades/Index.cshtml");
        }

        #region [Medicina]
        /// <summary>
        /// Cardiologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Cardiologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Cardiologia.cshtml");
        }

        /// <summary>
        /// Alergia Asma Inmunologia
        /// </summary>
        /// <returns></returns>
        public IActionResult AlergiaAsmaInmunologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/AlergiaAsmaInmunologia.cshtml");
        }

        /// <summary>
        /// Gastroenterologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Gastroenterologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Gastroenterologia.cshtml");
        }

        /// <summary>
        /// Dermatologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Dermatologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Dermatologia.cshtml");
        }

        /// <summary>
        /// Endocrinologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Endocrinologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Endocrinologia.cshtml");
        }

        /// <summary>
        /// Hematologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Hematologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Hematologia.cshtml");
        }

        /// <summary>
        /// Infectologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Infectologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Infectologia.cshtml");
        }

        /// <summary>
        /// Medicina Adolescente
        /// </summary>
        /// <returns></returns>
        public IActionResult MedicinaAdolescente()
        {
            return View("~/Views/Home/Especialidades/Medicina/MedicinaAdolescente.cshtml");
        }

        /// <summary>
        /// Medicina Fisica
        /// </summary>
        /// <returns></returns>
        public IActionResult MedicinaFisica()
        {
            return View("~/Views/Home/Especialidades/Medicina/MedicinaFisica.cshtml");
        }

        /// <summary>
        /// Medicina Pediatrica
        /// </summary>
        /// <returns></returns>
        public IActionResult MedicinaPediatrica()
        {
            return View("~/Views/Home/Especialidades/Medicina/MedicinaPediatrica.cshtml");
        }

        /// <summary>
        /// Nefrologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Nefrologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Nefrologia.cshtml");
        }

        /// <summary>
        /// Neonatologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Neonatologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Neonatologia.cshtml");
        }

        /// <summary>
        /// Neumologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Neumologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Neumologia.cshtml");
        }

        /// <summary>
        /// Neurologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Neurologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Neurologia.cshtml");
        }

        /// <summary>
        /// Reumatologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Reumatologia()
        {
            return View("~/Views/Home/Especialidades/Medicina/Reumatologia.cshtml");
        }

        /// <summary>
        /// Unidad Cuidado Paliativos
        /// </summary>
        /// <returns></returns>
        public IActionResult UnidadCuidadoPaliativos()
        {
            return View("~/Views/Home/Especialidades/Medicina/UnidadCuidadoPaliativos.cshtml");
        }
        #endregion

        #region [Cirugía]
        /// <summary>
        /// Cirugia Cabeza
        /// </summary>
        /// <returns></returns>
        public IActionResult CirugiaCabeza()
        {
            return View("~/Views/Home/Especialidades/Cirugia/CirugiaCabeza.cshtml");
        }

        /// <summary>
        /// Cirugia Pediatrica
        /// </summary>
        /// <returns></returns>
        public IActionResult CirugiaPediatrica()
        {
            return View("~/Views/Home/Especialidades/Cirugia/CirugiaPediatrica.cshtml");
        }

        /// <summary>
        /// Cirugia Plastica
        /// </summary>
        /// <returns></returns>
        public IActionResult CirugiaPlastica()
        {
            return View("~/Views/Home/Especialidades/Cirugia/CirugiaPlastica.cshtml");
        }

        /// <summary>
        /// Cirugia Torax Cardiovascular
        /// </summary>
        /// <returns></returns>
        public IActionResult CirugiaToraxCardiovascular()
        {
            return View("~/Views/Home/Especialidades/Cirugia/CirugiaToraxCardiovascular.cshtml");
        }

        /// <summary>
        /// Ginecologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Ginecologia()
        {
            return View("~/Views/Home/Especialidades/Cirugia/Ginecologia.cshtml");
        }

        /// <summary>
        /// Neurocirugia
        /// </summary>
        /// <returns></returns>
        public IActionResult Neurocirugia()
        {
            return View("~/Views/Home/Especialidades/Cirugia/Neurocirugia.cshtml");
        }

        /// <summary>
        /// Oftalmologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Oftalmologia()
        {
            return View("~/Views/Home/Especialidades/Cirugia/Oftalmologia.cshtml");
        }

        /// <summary>
        /// Otorrinolaringologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Otorrinolaringologia()
        {
            return View("~/Views/Home/Especialidades/Cirugia/Otorrinolaringologia.cshtml");
        }

        /// <summary>
        /// Quemados
        /// </summary>
        /// <returns></returns>
        public IActionResult Quemados()
        {
            return View("~/Views/Home/Especialidades/Cirugia/Quemados.cshtml");
        }

        /// <summary>
        /// Traumatologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Traumatologia()
        {
            return View("~/Views/Home/Especialidades/Cirugia/Traumatologia.cshtml");
        }

        /// <summary>
        /// Urologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Urologia()
        {
            return View("~/Views/Home/Especialidades/Cirugia/Urologia.cshtml");
        }
        #endregion

        #region  [Salud Mental]
        /// <summary>
        /// Psicologia
        /// </summary>
        /// <returns></returns>
        public IActionResult Psicologia()
        {
            return View("~/Views/Home/Especialidades/SaludMental/Psicologia.cshtml");
        }

        /// <summary>
        /// Psiquiatria
        /// </summary>
        /// <returns></returns>
        public IActionResult Psiquiatria()
        {
            return View("~/Views/Home/Especialidades/SaludMental/Psiquiatria.cshtml");
        }
        #endregion

        #region [Centro Vacunación]
        /// <summary>
        /// Inmunizacion
        /// </summary>
        /// <returns></returns>
        public IActionResult Inmunizacion()
        {
            return View("~/Views/Home/Especialidades/CentroVacunacion/Inmunizacion.cshtml");
        }
        #endregion

        #region [Emergencia]
        /// <summary>
        /// Servicio Emergencia
        /// </summary>
        /// <returns></returns>
        public IActionResult ServicioEmergencia()
        {
            return View("~/Views/Home/Especialidades/Emergencia/ServicioEmergencia.cshtml");
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}