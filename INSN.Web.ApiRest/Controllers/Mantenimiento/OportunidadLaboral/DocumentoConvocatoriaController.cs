using INSN.Web.Models.Response;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Request.Home;
using INSN.Web.Services.Interfaces.Mantenimiento.OportunidadLaboral;
using INSN.Web.Models.Response.Mantenimiento.OportunidadLaboral;

namespace INSN.Web.ApiRest.Controllers.Mantenimiento.OportunidadLaboral
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/Mantenimiento/OportunidadLaboral/[controller]")]
    [ApiController]
    public class DocumentoConvocatoriaController : ControllerBase
    {
        private readonly IDocumentoConvocatoriaService _service;

        /// <summary>
        /// Documento Convocatoria Controller
        /// </summary>
        /// <param name="service"></param>
        public DocumentoConvocatoriaController(IDocumentoConvocatoriaService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Documento Convocatoria Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("DocumentoConvocatoriaListar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<DocumentoConvocatoriaDtoResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<DocumentoConvocatoriaDtoResponse>>))]
        public async Task<IActionResult> DocumentoConvocatoriaListar([FromQuery] ConvocatoriaDtoRequest request)
        {
            var response = await _service.DocumentoConvocatoriaListar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}