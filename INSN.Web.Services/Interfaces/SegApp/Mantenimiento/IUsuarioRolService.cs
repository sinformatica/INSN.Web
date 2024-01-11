using INSN.Web.Models.Request.SegApp.Mantenimiento;
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
    /// Interface Servicio Usuario Rol
    /// </summary>
    public interface IUsuarioRolService
    {
        /// <summary>
        /// Usuario Rol Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<UsuarioRolDtoResponse>>> UsuarioRolListar(string UserId);

        /// <summary>
        /// IService: Usuario Rol Asignar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> UsuarioRolAsignar(UsuarioRolDtoRequest request);

        /// <summary>
        /// IService: Usuario Rol Eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<BaseResponse> UsuarioRolEliminar(int Id);
    }
}
