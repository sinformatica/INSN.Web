using Microsoft.AspNetCore.Mvc;
using INSN.Web.Services.Interfaces.Home.LibroReclamaciones;
using INSN.Web.Models.Request.Home.LibroReclamaciones;

namespace INSN.Web.ApiRest.Controllers.Home.LibroReclamacion
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/Home/LibroReclamacion/[controller]")]
    [ApiController]
    public class LibroReclamacionController : ControllerBase
    {
        private readonly ILibroReclamacionService _service;

        /// <summary>
        /// Libro Reclamacion Controller
        /// </summary>
        /// <param name="service"></param>
        public LibroReclamacionController(ILibroReclamacionService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Libro Reclamacion Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("LibroReclamacionInsertar")]
        public async Task<IActionResult> LibroReclamacionInsertar(LibroReclamacionDtoRequest request)
        {
            var response = await _service.LibroReclamacionInsertar(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}