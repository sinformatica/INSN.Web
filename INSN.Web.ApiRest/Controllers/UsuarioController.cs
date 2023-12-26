using Azure.Core;
using INSN.Web.Common;
using INSN.Web.Models;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace INSN.Web.ApiRest.Controllers
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginDtoRequest request)
        {
            var response = await _service.Login(request);
            return response.Success ? Ok(response) : Unauthorized(response);
        }

        /// <summary>
        /// ApiRest: SistemasPorUsuarioListar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SistemasPorUsuarioListar([FromQuery] LoginUsuarioDtoRequest request)
        {
            var response = await _service.SistemasPorUsuarioListar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: LoginSistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginSistema(LoginSistemaDtoRequest request)
        {
            var response = await _service.LoginSistema(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: UsuarioInsertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthorizeMultipleRoles(Constantes.RolAdminSistemas)]
        public async Task<IActionResult> UsuarioInsertar(UsuarioDtoRequest request)
        {
            var response = await _service.UsuarioInsertar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: RolInsertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthorizeMultipleRoles(Constantes.RolAdminSistemas)]
        public async Task<IActionResult> RolInsertar(string nombreRol)
        {
            var response = await _service.RolInsertar(nombreRol);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: RolesUsuarioAsignar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthorizeMultipleRoles(Constantes.RolAdminSistemas)]
        public async Task<IActionResult> RolesUsuarioAsignar(UsuarioRolDtoRequest request)
        {
            var response = await _service.RolesUsuarioAsignar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
