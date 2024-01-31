﻿using INSN.Web.Models.Response;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Request.Home;
using INSN.Web.Services.Interfaces.Home.OportunidadLaboral;
using INSN.Web.Models.Response.Home.OportunidadLaboral;

namespace INSN.Web.ApiRest.Controllers.Home.OportunidadLaboral
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/Home/OportunidadLaboral/[controller]")]
    [ApiController]
    public class DocumentoConvocatoriaController : ControllerBase
    {
        private readonly IConvocatoriaService _service;

        /// <summary>
        /// Documento Convocatoria Controller
        /// </summary>
        /// <param name="service"></param>
        public DocumentoConvocatoriaController(IConvocatoriaService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Documento Convocatoria Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("DocumentoConvocatoriaListar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<ConvocatoriaDtoResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<ConvocatoriaDtoResponse>>))]
        public async Task<IActionResult> DocumentoConvocatoriaListar([FromQuery] ConvocatoriaDtoRequest request)
        {
            var response = await _service.DocumentoConvocatoriaListar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}