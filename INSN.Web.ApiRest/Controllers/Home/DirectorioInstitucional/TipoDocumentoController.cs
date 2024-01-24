using INSN.Web.Models.Response;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Services.Interfaces.Home;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Request.Home;

namespace INSN.Web.ApiRest.Controllers.Home.Auxiliar
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/Home/DirectorioInstitucional/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoService _service;

        /// <summary>
        /// TipoDocumento Controller
        /// </summary>
        /// <param name="service"></param>
        public TipoDocumentoController(ITipoDocumentoService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: TipoDocumento Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("TipoDocumentoListar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<TipoDocumentoDtoResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<TipoDocumentoDtoResponse>>))]
        public async Task<IActionResult> TipoDocumentoListar([FromQuery] TipoDocumentoDtoRequest request)
        {
            var response = await _service.TipoDocumentoListar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
