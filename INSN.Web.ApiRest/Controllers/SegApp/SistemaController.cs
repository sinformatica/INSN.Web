using INSN.Web.Models.Response;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Services.Interfaces.SegApp;
using INSN.Web.Models.Response.Sistemas;
using INSN.Web.Common;
using Microsoft.AspNetCore.Authorization;

namespace INSN.Web.ApiRest.Controllers.SegApp
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [ApiController]
    [Route("api/SegApp/[controller]")]
    [ServiceFilter(typeof(CodigoSistemaIdAutorizacion))]
    public class SistemaController : ControllerBase
    {
        private readonly ISistemaService _service;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="service"></param>
        public SistemaController(ISistemaService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Sistema Listar
        /// </summary>
        /// <returns></returns>
        [HttpGet("SistemaListar")]
        [Authorize(Roles = $"{Constantes.RolAdminSistemas}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<SistemaDtoResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<SistemaDtoResponse>>))]
        public async Task<IActionResult> SistemaListar()
        {
            var response = await _service.SistemaListar();
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}