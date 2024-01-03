using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Services.Interfaces.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.ApiRest.Controllers.SegApp.Rol
{
    /// <summary>
    /// Creador de API
    /// </summary>
    //[Route("api/SegApp/Mantenimiento/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class RolController : ControllerBase
    {
        private readonly IRolService _service;

        /// <summary>
        /// Rol Controller
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
        //[HttpGet("RolListar")]
        //[ProducesResponseType((int)StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<RolDtoResponse>>))]
        //[ProducesResponseType((int)StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<RolDtoResponse>>))]
        [HttpGet]
        public async Task<IActionResult> RolListar()
        {
            //var response = await _service.RolListar(request);
            //return response.Success ? Ok(response) : BadRequest(response);
            string a = "";
            return Ok();
        }
    }
}
