using INSN.Web.Models.Request;
using INSN.Web.Models;
using INSN.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.ViewModels.SegApp.Mantenimiento;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.ViewModels.SegApp;
using INSN.Web.Portal.Services.Interfaces.SegApp;

namespace INSN.Web.Portal.Controllers.SegApp
{
    public class TipoDocumentoIdentidadController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly ITipoDocumentoIdentidadProxy _proxy;
        private readonly ILogger<TipoDocumentoIdentidadController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public TipoDocumentoIdentidadController(ITipoDocumentoIdentidadProxy proxy,
                        ILogger<TipoDocumentoIdentidadController> logger,
                        IWebHostEnvironment env)
        {
            _proxy = proxy;
            _logger = logger;
            _enviroment = env;
        }

        /// <summary>
        /// Modelo Tipo Documento Identidad
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> TipoDocumentoIdentidadListar(TipoDocumentoIdentidadViewModel model)
        {
            var response = await _proxy.TipoDocumentoIdentidadListar(new TipoDocumentoIdentidadDtoRequest()
            {
            });

            model.TiposDocIdentidad = response;
            return View("~/Views/SegApp/Mantenimiento/Usuario/Index.cshtml", model);
        }
    }
}
