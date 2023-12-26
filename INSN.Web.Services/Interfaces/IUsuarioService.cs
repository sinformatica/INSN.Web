using INSN.Web.Models.Response;
using INSN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Response.Sistemas;

namespace INSN.Web.Services.Interfaces
{
    /// <summary>
    /// Interface Servicio Usuario
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        /// IService: Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginDtoResponse> Login(LoginDtoRequest request);

        /// <summary>
        /// IService: Sistemas Por Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<SistemaDtoResponse>>> SistemasPorUsuarioListar(LoginUsuarioDtoRequest request);

        /// <summary>
        /// IService: Login Sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginDtoResponse> LoginSistema(LoginSistemaDtoRequest request);

        /// <summary>
        /// IService: Usuario Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> UsuarioInsertar(UsuarioDtoRequest request);

        /// <summary>
        /// IService: Rol Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> RolInsertar(string nombreRol);

        /// <summary>
        /// IService: Roles Usuario Asignar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> RolesUsuarioAsignar(UsuarioRolDtoRequest request);
    }
}
