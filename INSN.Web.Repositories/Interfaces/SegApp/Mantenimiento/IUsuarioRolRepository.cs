using INSN.Web.Entities.Info.Mantenimiento;
using INSN.Web.Entities.SegApp;

namespace INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento
{
    public interface IUsuarioRolRepository : IRepositoryBaseSegAppEF<UsuarioRol>
    {
        /// <summary>
        /// IRepository: Usuario Rol Listar
        /// </summary>
        Task<ICollection<UsuarioRolInfo>> UsuarioRolListar(string UserId);
    }
}