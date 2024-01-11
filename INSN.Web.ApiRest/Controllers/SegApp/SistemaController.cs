﻿using INSN.Web.Models.Response;
using INSN.Web.Models;
using INSN.Web.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Services.Interfaces.SegApp;
using INSN.Web.Models.Response.Sistemas;

namespace INSN.Web.ApiRest.Controllers.SegApp
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [Route("api/SegApp/[controller]")]
    [ApiController]
    public class SistemaController : ControllerBase
    {
        private readonly ISistemaService _service;

        /// <summary>
        /// Tipo Documento Identidad Controller
        /// </summary>
        /// <param name="service"></param>
        public SistemaController(ISistemaService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Sistema Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("SistemaListar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<SistemaDtoResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<SistemaDtoResponse>>))]
        public async Task<IActionResult> SistemaListar()
        {
            var response = await _service.SistemaListar();
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}