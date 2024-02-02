using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp;
using INSN.Web.Services.Interfaces.SegApp;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.ApiRest.Controllers.SegApp
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [ApiController]
    [Route("api/SegApp/[controller]")]
    public class TipoDocumentoIdentidadController : ControllerBase
    {
        private readonly ITipoDocumentoIdentidadService _service;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="service"></param>
        public TipoDocumentoIdentidadController(ITipoDocumentoIdentidadService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Tipo Documento Identidad Listar
        /// </summary>
        /// <returns></returns>
        [HttpGet("TipoDocumentoIdentidadListar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<TipoDocumentoIdentidadDtoResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<TipoDocumentoIdentidadDtoResponse>>))]
        public async Task<IActionResult> TipoDocumentoIdentidadListar()
        {
            var response = await _service.TipoDocumentoIdentidadListar();
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}