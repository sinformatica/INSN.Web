using INSN.Web.Models.Response;
using INSN.Web.Services.Interfaces.Mantenimiento.Comunicados;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Response.Mantenimiento.Comunicados;
using INSN.Web.Models.Request.Mantenimiento.Comunicados;

namespace INSN.Web.ApiRest.Controllers.Mantenimiento.Comunicados
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [ApiController]
    [Route("api/Mantenimiento/Comunicado/[controller]")]
    public class ComunicadoController : ControllerBase
    {
        private readonly IComunicadoService _service;

        /// <summary>
        /// Documento Legal Controller
        /// </summary>
        /// <param name="service"></param>
        public ComunicadoController(IComunicadoService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Comunicado Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("ComunicadoListar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<ComunicadoDtoResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<ComunicadoDtoResponse>>))]
        public async Task<IActionResult> ComunicadoListar([FromQuery] ComunicadoDtoRequest request)
        {
            var response = await _service.ComunicadoListar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
