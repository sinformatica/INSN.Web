using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Services.Interfaces.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using INSN.Web.Common;

namespace INSN.Web.ApiRest.Controllers.SegApp.Mantenimiento
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/SegApp/Mantenimiento/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        /// <summary>
        /// Usuario Controller
        /// </summary>
        /// <param name="service"></param>
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("UsuarioListar")]
        [ProducesResponseType((int)StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<UsuarioDtoResponse>>))]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<UsuarioDtoResponse>>))]
        public async Task<IActionResult> UsuarioListar([FromQuery] UsuarioDtoRequest request)
        {
            var response = await _service.UsuarioListar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Usuario Buscar Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("UsuarioBuscarId/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioDtoResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UsuarioBuscarId(string id)
        {
            var response = await _service.UsuarioBuscarId(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Usuario Validar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UsuarioValidar")]
        public async Task<IActionResult> UsuarioValidar(UsuarioDtoRequest request)
        {
            var response = await _service.UsuarioValidar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Usuario Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UsuarioInsertar")]
        public async Task<IActionResult> UsuarioInsertar(UsuarioDtoRequest request)
        {
            var response = await _service.UsuarioInsertar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Usuario Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UsuarioActualizar")]
        public async Task<IActionResult> UsuarioActualizar(UsuarioDtoRequest request)
        {
            var response = await _service.UsuarioActualizar(request);
            return response.Success ? Ok(response) : NotFound(response);
        }

        /// <summary>
        /// ApiRest: Usuario Eliminar Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("UsuarioEliminar/{Id}")]
        [ProducesResponseType((int)StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<UsuarioDtoResponse>>))]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<UsuarioDtoResponse>>))]
        public async Task<IActionResult> UsuarioEliminar(string Id)
        {
            var response = await _service.UsuarioEliminar(Id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Usuario Actualizar Clave
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UsuarioActualizarClave")]
        public async Task<IActionResult> UsuarioActualizarClave(UsuarioDtoRequest request)
        {
            var response = await _service.UsuarioActualizarClave(request);
            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
