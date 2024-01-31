using INSN.Web.Entities.SegApp;
namespace INSN.Web.Repositories.Interfaces.SegApp
{
    /// <summary>
    /// Interface de Metodos TipoDocumentoIdentidad
    /// </summary>
    public interface ITipoDocumentoIdentidadRepository : IRepositoryBaseSegAppEF<TipoDocumentoIdentidad>
    {
        /// <summary>
        /// IRepository: Tipo Documento Identidad Listar
        /// </summary>
        Task<ICollection<TipoDocumentoIdentidad>> TipoDocumentoIdentidadListar();
    }
}