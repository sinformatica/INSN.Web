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
        /// Api  de Método Listar
        /// </summary>
        /// <param name="Documento"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _service.ListAsync();

            return Ok(response);
        }
    }
}