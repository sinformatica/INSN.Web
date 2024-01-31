using INSN.Web.Models.Request.Home.Comunicados;
using INSN.Web.Models.Response.Home.Comunicados;
using INSN.Web.Portal.Models;
using INSN.Web.Portal.Services.Interfaces.Home.Comunicados;
using INSN.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace INSN.Web.Portal.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IComunicadoProxy _proxyComunicado;

        public HomeController(ILogger<HomeController> logger, IComunicadoProxy proxyComunicado)
        {
            _logger = logger;
            _proxyComunicado = proxyComunicado;
        }

        public IActionResult Index()
        {
            PrincipalViewModel model = new PrincipalViewModel();
            var resultComunicados = ComunicadoListar();
            model.ComunicadoLista = resultComunicados.Result;

            foreach (var item in model.ComunicadoLista)
            {
                var resultDetalle = _proxyComunicado.ComunicadoDetalleListar(item.CodigoComunicadoId);
                item.DetalleLista = resultDetalle.Result;
            }

            return View("~/Views/Home/Index.cshtml", model);
        }

        public IActionResult Nosotros()
        {
            return View();
        }
        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Especialidades()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region[Comunicado]
        /// <summary>
        /// Comunicado Listar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<List<ComunicadoDtoResponse>> ComunicadoListar()
        {
            var result = await _proxyComunicado.ComunicadoListar(new ComunicadoDtoRequest()
            {
                Titulo = "",
                FechaExpiracion = DateTime.Now,
                Estado = "A",
                EstadoRegistro = 1
            });

            return (List<ComunicadoDtoResponse>)result;
        }
        #endregion
    }
}