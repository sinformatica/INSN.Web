using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response;

namespace INSN.Web.Services.Interfaces.SegApp.Mantenimiento
{
    /// <summary>
    /// IUsuarioRolService
    /// </summary>
    public interface IUsuarioRolService
    {
        /// <summary>
        /// Usuario Rol Listar
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<UsuarioRolDtoResponse>>> UsuarioRolListar(string UserId);

        /// <summary>
        /// IService: Usuario Rol Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> UsuarioRolInsertar(UsuarioRolDtoRequest request);

        /// <summary>
        /// IService: Usuario Rol Eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<BaseResponse> UsuarioRolEliminar(int Id);
    }
}