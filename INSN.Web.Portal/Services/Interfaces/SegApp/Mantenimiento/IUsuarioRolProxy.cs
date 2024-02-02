using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;

namespace INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento
{
    /// <summary>
    /// IUsuarioRolProxy
    /// </summary>
    public interface IUsuarioRolProxy : ICrudRestHelper<UsuarioRolDtoRequest, UsuarioRolDtoResponse>
    {
        /// <summary>
        /// IProxy: Usuario Rol Listar
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<ICollection<UsuarioRolDtoResponse>> UsuarioRolListar(string UserId);

        /// <summary>
        /// IProxy: Usuario Rol Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UsuarioRolInsertar(UsuarioRolDtoRequest request);

        /// <summary>
        /// IProxy: Usuario Rol Eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UsuarioRolEliminar(int id);
    }
}