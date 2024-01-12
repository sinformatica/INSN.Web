using INSN.Web.Models;
using INSN.Web.Models.Request.Sistema;
using INSN.Web.Services.Interfaces.Acceso;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.ApiRest.Controllers.Acceso
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/Acceso/[controller]/[action]")]
    [ApiController]

    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public MenuController(IMenuService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Seccion Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SeccionListar([FromQuery] SeccionDtoRequest request)
        {
            var response = await _service.SeccionListar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Modulo Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ModuloListar([FromQuery] ModuloDtoRequest request)
        {
            var response = await _service.ModuloListar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
