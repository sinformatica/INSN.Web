using INSN.Web.Services.Interfaces.Home;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.ApiRest.Controllers.Home
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoService _service;

        public TipoDocumentoController(ITipoDocumentoService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Area"></param>
        /// <param name="Estado"></param>
        /// <param name="EstadoRegistro"></param>
        /// <returns></returns>
        [HttpGet("TipoDocumentoListar")]
        public async Task<IActionResult> Get(string Area, string Estado, int EstadoRegistro)
        {
            var response = await _service.ListAsync(Area, Estado, EstadoRegistro);

            return Ok(response);
        }
    }
}