using INSN.Web.Entities.SegApp;

namespace INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento
{
    /// <summary>
    /// Interface de Metodos Rol
    /// </summary>
    public interface IRolRepository : IRepositoryBaseSegAppEF<Rol>
    {
        /// <summary>
        /// IRepository: Rol Listar
        /// </summary>
        Task<ICollection<Rol>> RolListar(Rol request);

        /// <summary>
        /// IRepository: Rol Por Sistema Listar
        /// </summary>
        Task<ICollection<Rol>> RolPorSistemaListar(int CodigoSistemaId);
    }
}