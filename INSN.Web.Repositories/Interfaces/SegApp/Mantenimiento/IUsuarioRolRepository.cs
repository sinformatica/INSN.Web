using INSN.Web.Entities.Info.Mantenimiento;
using INSN.Web.Entities.SegApp;

namespace INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento
{
    /// <summary>
    /// Interface: IUsuarioRol
    /// </summary>
    public interface IUsuarioRolRepository : IRepositoryBaseSegAppEF<UsuarioRol>
    {
        /// <summary>
        /// IRepository: Usuario Rol Listar
        /// </summary>
        Task<ICollection<UsuarioRolInfo>> UsuarioRolListar(string UserId);
    }
}