using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response;
using INSN.Web.Services.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.Services.Interfaces.Mantenimiento.Comunicados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Response.Mantenimiento.Comunicados;
using INSN.Web.Models.Request.Mantenimiento.Comunicados;

namespace INSN.Web.ApiRest.Controllers.Mantenimiento.Comunicados
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [ApiController]
    [Route("api/Mantenimiento/[controller]")]
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

        #region[Comunicado]
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
        #endregion

        #region[Comunicado Detalle]
        /// <summary>
        /// ApiRest: Comunicado Detalle Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("ComunicadoDetalleListar/{CodigoComunicadoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<ComunicadoDetalleDtoResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<ComunicadoDetalleDtoResponse>>))]
        public async Task<IActionResult> ComunicadoDetalleListar(int CodigoComunicadoId)
        {
            var response = await _service.ComunicadoDetalleListar(CodigoComunicadoId);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        #endregion
    }
}
