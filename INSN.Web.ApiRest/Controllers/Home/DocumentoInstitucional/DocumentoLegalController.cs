﻿using INSN.Web.Models.Response;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Services.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.Models.Request.Home.DocumentoLegal;
using INSN.Web.Models.Response.Home.DocumentoLegal;

namespace INSN.Web.ApiRest.Controllers.Home.DocumentoInstitucional
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/Home/DocumentoInstitucional/[controller]")]
    [ApiController]
    public class DocumentoLegalController : ControllerBase
    {
        private readonly IDocumentoLegalService _service;

        /// <summary>
        /// Documento Legal Controller
        /// </summary>
        /// <param name="service"></param>
        public DocumentoLegalController(IDocumentoLegalService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Documento Legal Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("DocumentoLegalListar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<DocumentoLegalDtoResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<DocumentoLegalDtoResponse>>))]
        public async Task<IActionResult> DocumentoLegalListar([FromQuery] DocumentoLegalDtoRequest request)
        {
            var response = await _service.DocumentoLegalListar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}