using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home;
using INSN.Web.Services.Interfaces.Home;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.ApiRest.Controllers
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/Home/[controller]")]
    [ApiController]
    public class TipoDocumentossController : ControllerBase
    {
        private readonly ITipoDocumentoService _service;

        public TipoDocumentossController(ITipoDocumentoService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Tipo Documento Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("TipoDocumentoListar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<TipoDocumentoDtoResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<TipoDocumentoDtoResponse>>))]
        public async Task<IActionResult> TipoDocumentoListar(TipoDocumentoDtoRequest request)
        {
            var response = await _service.TipoDocumentoListar(request);

            return Ok(response);
        }
    }
}