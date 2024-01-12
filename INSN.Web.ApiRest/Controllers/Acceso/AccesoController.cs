using Azure.Core;
using INSN.Web.Common;
using INSN.Web.Models.Request.Acceso;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Services.Interfaces.Acceso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace INSN.Web.ApiRest.Controllers.Acceso
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/Acceso/[controller]/[action]")]
    [ApiController]

    public class AccesoController : ControllerBase
    {
        private readonly IAccesoService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public AccesoController(IAccesoService service)
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
    }
}
