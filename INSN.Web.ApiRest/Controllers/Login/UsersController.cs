﻿using Azure.Core;
using INSN.Web.Common;
using INSN.Web.Models;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace INSN.Web.ApiRest.Controllers.Login
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        //[AuthorizeMultipleRoles(Constantes.RolJefe, Constantes.RolUsuario)]
        public async Task<IActionResult> Login(LoginDtoRequest request)
        {
            var response = await _service.LoginAsync(request);
            return response.Success ? Ok(response) : Unauthorized(response);
        }

        [HttpPost]
        //[AuthorizeMultipleRoles(Constantes.RolAdminSistemas)]
        public async Task<IActionResult> RegistrarUsuario(UsuarioDtoRequest request)
        {
            var response = await _service.RegistrarUsuarioAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        //[AuthorizeMultipleRoles(Constantes.RolAdminSistemas)]
        public async Task<IActionResult> RegistrarRol(string nombreRol)
        {
            var response = await _service.RegistrarRolAsync(nombreRol);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        //[AuthorizeMultipleRoles(Constantes.RolAdminSistemas)]
        public async Task<IActionResult> AsignarRolesUsuario(UsuarioRolDtoRequest request)
        {
            var response = await _service.AsignarRolesUsuarioAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}