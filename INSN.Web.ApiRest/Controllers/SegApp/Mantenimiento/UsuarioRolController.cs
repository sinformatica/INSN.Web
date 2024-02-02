using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Services.Interfaces.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Common;
using Microsoft.AspNetCore.Authorization;

namespace INSN.Web.ApiRest.Controllers.SegApp.Mantenimiento
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [ApiController]
    [Route("api/SegApp/Mantenimiento/[controller]")]
    [ServiceFilter(typeof(CodigoSistemaIdAutorizacion))]
    public class UsuarioRolController : ControllerBase
    {
        private readonly IUsuarioRolService _service;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="service"></param>
        public UsuarioRolController(IUsuarioRolService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Usuario Rol Listar
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet("UsuarioRolListar/{UserId}")]
        [Authorize(Roles = $"{Constantes.RolAdminSistemas}")]
        [ProducesResponseType((int)StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<UsuarioRolDtoResponse>>))]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<UsuarioRolDtoResponse>>))]
        public async Task<IActionResult> UsuarioRolListar(string UserId)
        {
            var response = await _service.UsuarioRolListar(UserId);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Usuario Rol Asignar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UsuarioRolInsertar")]
        [Authorize(Roles = $"{Constantes.RolAdminSistemas}")]
        public async Task<IActionResult> UsuarioRolInsertar(UsuarioRolDtoRequest request)
        {
            var response = await _service.UsuarioRolInsertar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Usuario Rol Eliminar Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("UsuarioRolEliminar/{Id}")]
        [Authorize(Roles = $"{Constantes.RolAdminSistemas}")]
        [ProducesResponseType((int)StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<RolDtoResponse>>))]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<RolDtoResponse>>))]
        public async Task<IActionResult> UsuarioRolEliminar(int Id)
        {
            var response = await _service.UsuarioRolEliminar(Id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}