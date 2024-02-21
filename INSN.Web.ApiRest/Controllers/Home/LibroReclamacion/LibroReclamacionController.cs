using Microsoft.AspNetCore.Mvc;
using INSN.Web.Services.Interfaces.Home.LibroReclamaciones;
using INSN.Web.Models.Request.Home.LibroReclamaciones;
using INSN.Web.Common;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using INSN.Web.Models.Response.Home.LibroReclamaciones;

namespace INSN.Web.ApiRest.Controllers.Home.LibroReclamacion
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/Home/[controller]")]
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

        /// <summary>
        /// ApiRest: Libro Reclamacion Ruta Imagen Actualizar
        /// </summary>
        /// <param name="CodigoLibroReclamacionId"></param>
        /// <param name="RutaImagen"></param>
        /// <returns></returns>
        [HttpPut("LibroReclamacionRutaImagenActualizar")]
        public async Task<IActionResult> LibroReclamacionRutaImagenActualizar(int CodigoLibroReclamacionId, string RutaImagen)
        {
            var response = await _service.LibroReclamacionRutaImagenActualizar(CodigoLibroReclamacionId, RutaImagen);
            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}