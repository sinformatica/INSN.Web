﻿using INSN.Web.Models.Response;
using INSN.Web.Models;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Response.Sistemas;

namespace INSN.Web.Portal.Services.Interfaces
{
    /// <summary>
    /// Interface Proxy Usuario
    /// </summary>
    public interface IAccesoProxy
    {
        /// <summary>
        /// IProxy: Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginDtoResponse> Login(LoginDtoRequest request);

        /// <summary>
        /// IProxy: Sistemas Por Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<SistemaDtoResponse>> SistemasPorUsuarioListar(LoginUsuarioDtoRequest request);
    }
}
