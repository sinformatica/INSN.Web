using INSN.Web.Models;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Response;
using INSN.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.ApiRest.Controllers
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoIdentidadController : ControllerBase
    {
        private readonly ITipoDocumentoIdentidadService _service;

        /// <summary>
        /// Tipo Documento Identidad Controller
        /// </summary>
        /// <param name="service"></param>
        public TipoDocumentoIdentidadController(ITipoDocumentoIdentidadService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Tipo Documento Identidad Listar
        /// </summary>
        /// <param name="request"></param>
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
