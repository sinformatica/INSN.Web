using INSN.Web.Services.Interfaces.Home;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.ApiRest.Controllers.Home
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoLegalController : ControllerBase
    {
        private readonly IDocumentoLegalService _service;

        public DocumentoLegalController(IDocumentoLegalService service)
        {
            _service = service;
        }

        /// <summary>
        /// Api  de Método Listar
        /// </summary>
        /// <param name="Documento"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(string? Documento)
        {
            var response = await _service.ListAsync(Documento);

            return Ok(response);
        }
    }
}