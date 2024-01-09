﻿using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;

namespace INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento
{
    public interface IUsuarioProxy : ICrudRestHelper<UsuarioDtoRequest, UsuarioDtoResponse>
    {
        /// <summary>
        /// IProxy: Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<UsuarioDtoResponse>> UsuarioListar(UsuarioDtoRequest request);

        /// <summary>
        /// IProxy: Usuario Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UsuarioInsertar(UsuarioDtoRequest request);
    }
}
