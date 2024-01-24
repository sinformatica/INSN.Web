using INSN.Web.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Response.Sistemas;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.Acceso;
using INSN.Web.Models.Request.Acceso;

namespace INSN.Web.Services.Interfaces.Acceso
{
    /// <summary>
    /// Interface Servicio Usuario
    /// </summary>
    public interface IAccesoService
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

        ///// <summary>
        ///// IService: Rol Insertar
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //Task<BaseResponse> RolInsertar(string nombreRol);
    }
}
