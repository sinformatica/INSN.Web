using INSN.Web.Models.Request;
using INSN.Web.Models.Request.Home;
using INSN.Web.Services.Interfaces.Home;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.ApiRest.Controllers.Home
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoLegalController : ControllerBase
    {
        private readonly IDocumentoLegalService _service;

        public DocumentoLegalController(IDocumentoLegalService service)
        {
            _service = service;
        }

        /// <summary>
        /// Api  de Método Listar
        /// </summary>
        /// <param name="Documento"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BusquedaDocumentoLegalRequest request)
        {
            var response = await _service.ListAsync(request.Documento, request.Descripcion, request.TipoDocumentoId, request.Estado, request.EstadoRegistro, request.Page, request.Rows);

            return Ok(response);
        }
    }
}