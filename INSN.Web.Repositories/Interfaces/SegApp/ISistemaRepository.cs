using INSN.Web.Entities.SegApp;

namespace INSN.Web.Repositories.Interfaces.SegApp
{
    /// <summary>
    /// Interface Repository Sistema
    /// </summary>
    public interface ISistemaRepository : IRepositoryBaseSegAppEF<Sistema>
    {
        /// <summary>
        /// IRepository: Sistema
        /// </summary>
        Task<ICollection<Sistema>> SistemaListar();
    }
}