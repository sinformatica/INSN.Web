using INSN.Web.Common;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Services.Interfaces.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace INSN.Web.ApiRest.Controllers.SegApp.Rol
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [ApiController]
    [Route("api/SegApp/Mantenimiento/[controller]")]
    [ServiceFilter(typeof(CodigoSistemaIdAutorizacion))] 
    public class RolController : ControllerBase
    {
        private readonly IRolService _service;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="service"></param>
        public RolController(IRolService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Rol Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("RolListar")]
        [Authorize(Roles = $"{Constantes.RolAdminSistemas}")]
        [ProducesResponseType((int)StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<RolDtoResponse>>))]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<RolDtoResponse>>))]
        public async Task<IActionResult> RolListar([FromQuery] RolDtoRequest request)
        {
            //var codigoSistemaIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CodigoSistemaId")?.Value;

            //if (codigoSistemaIdClaim != Constantes.CodigoSistemaIdFijo)
            //{
            //    // No tiene el CodigoSistemaId permitido, devolver un UnauthorizedResult
            //    return Unauthorized();
            //}

            var response = await _service.RolListar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Rol Buscar Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("RolBuscarId/{id}")]
        [Authorize(Roles = $"{Constantes.RolAdminSistemas}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RolDtoResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> RolBuscarId(string id)
        {
            var response = await _service.RolBuscarId(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Rol Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("RolInsertar")]
        [Authorize(Roles = $"{Constantes.RolAdminSistemas}")]
        public async Task<IActionResult> RolInsertar(RolDtoRequest request)
        {
            var response = await _service.RolInsertar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Rol Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("RolActualizar")]
        [Authorize(Roles = $"{Constantes.RolAdminSistemas}")]
        public async Task<IActionResult> RolActualizar(RolDtoRequest request)
        {
            var response = await _service.RolActualizar(request);
            return response.Success ? Ok(response) : NotFound(response);
        }

        /// <summary>
        /// ApiRest: Rol Eliminar Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("RolEliminar/{Id}")]
        [Authorize(Roles = $"{Constantes.RolAdminSistemas}")]
        [ProducesResponseType((int)StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<RolDtoResponse>>))]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<RolDtoResponse>>))]
        public async Task<IActionResult> RolEliminar(string Id)
        {
            var response = await _service.RolEliminar(Id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Rol Por Sistema Listar
        /// </summary>
        /// <param name="CodigoSistemaId"></param>
        /// <returns></returns>
        [HttpGet("RolPorSistemaListar/{CodigoSistemaId}")]
        [Authorize(Roles = $"{Constantes.RolAdminSistemas}")]
        [ProducesResponseType((int)StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<RolDtoResponse>>))]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<RolDtoResponse>>))]
        public async Task<IActionResult> RolPorSistemaListar(int CodigoSistemaId)
        {
            var response = await _service.RolPorSistemaListar(CodigoSistemaId);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}