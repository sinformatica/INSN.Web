using INSN.Web.Models.Response.Util;
using INSN.Web.Services.Interfaces.Util;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace INSN.Web.ApiRest.Controllers.Util
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [ApiController]
    [Route("api/Util/[controller]")]
    public class CorreoCredencialController : ControllerBase
    {
        private readonly ICorreoCredencialService _service;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="service"></param>
        public CorreoCredencialController(ICorreoCredencialService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Obtener Correo Credencial
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObtenerCorreoCredencial")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CorreoCredencialDtoResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObtenerCorreoCredencial()
        {
            var response = await _service.ObtenerCorreoCredencial();
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}