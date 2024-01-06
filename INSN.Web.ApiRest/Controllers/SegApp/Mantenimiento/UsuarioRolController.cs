using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Services.Interfaces.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Common;

namespace INSN.Web.ApiRest.Controllers.SegApp.Mantenimiento
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/SegApp/Mantenimiento/[controller]")]
    [ApiController]
    public class UsuarioRolController : ControllerBase
    {
        private readonly IUsuarioRolService _service;

        /// <summary>
        /// Usuario Controller
        /// </summary>
        /// <param name="service"></param>
        public UsuarioRolController(IUsuarioRolService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Usuario Rol Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("UsuarioRolListar")]
        [ProducesResponseType((int)StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<UsuarioRolDtoResponse>>))]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<UsuarioRolDtoResponse>>))]
        public async Task<IActionResult> UsuarioRolListar([FromQuery] UsuarioRolDtoRequest request)
        {
            var response = await _service.UsuarioRolListar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Usuario Rol Asignar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UsuarioRolAsignar")]
        [AuthorizeByRolesAndCodigoSistemaId(Constantes.CodigoSistemaId, Constantes.RolAdminSistemas)]
        //[AuthorizeByCodigoSistemaId(Constantes.CodigoSistemaId)]
        //[AuthorizeMultipleRoles(Constantes.RolAdminSistemas)]
        public async Task<IActionResult> UsuarioRolAsignar(UsuarioRolDtoRequest request)
        {
            var response = await _service.UsuarioRolAsignar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
