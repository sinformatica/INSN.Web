using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Request.Home;
using INSN.Web.Services.Interfaces.Mantenimiento.OportunidadLaboral;

namespace INSN.Web.ApiRest.Controllers.Mantenimiento.LibroReclamacion
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/Mantenimiento/LibroReclamacion/[controller]")]
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