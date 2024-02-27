using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.ViewModels.SegApp;
using INSN.Web.Portal.Services.Interfaces.SegApp;

namespace INSN.Web.Portal.Controllers.SegApp
{
    /// <summary>
    /// TipoDocumentoIdentidadController
    /// </summary>
    public class TipoDocumentoIdentidadController : Controller
    {
        private readonly ITipoDocumentoIdentidadProxy _proxy;

        /// <summary>
        /// Instanciar
        /// </summary>
        /// <param name="proxy"></param>
        public TipoDocumentoIdentidadController(ITipoDocumentoIdentidadProxy proxy)
        {
            _proxy = proxy;
        }

        /// <summary>
        /// Tipo Documento Identidad Listar
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