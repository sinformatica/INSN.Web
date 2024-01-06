﻿using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Services.Interfaces.SegApp.Mantenimiento
{
    /// <summary>
    /// Interface Servicio Usuario
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        /// Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<UsuarioDtoResponse>>> UsuarioListar(UsuarioDtoRequest request);

        /// <summary>
        /// IService: Usuario Buscar Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<UsuarioDtoResponse>> UsuarioBuscarId(string Id);

        /// <summary>
        /// IService: Usuario Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> UsuarioInsertar(UsuarioDtoRequest request);

        /// <summary>
        /// IService: Usuario Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> UsuarioActualizar(UsuarioDtoRequest request);

        /// <summary>
        /// IService: Usuario Eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<BaseResponse> UsuarioEliminar(string Id);
    }
}
