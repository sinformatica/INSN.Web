using INSN.Web.Entities.SegApp;

namespace INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento
{
    /// <summary>
    /// Interface de Metodos Usuario
    /// </summary>
    public interface IUsuarioRepository : IRepositoryBaseSegAppEF<Usuario>
    {
        /// <summary>
        /// IRepository: Usuario Listar
        /// </summary>
        Task<ICollection<UsuarioInfo>> UsuarioListar(Usuario request);
    }
}