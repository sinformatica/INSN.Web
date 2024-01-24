using INSN.Web.Entities.DocumentoLegal;

namespace INSN.Web.Repositories.Interfaces.Home
{
    /// <summary>
    /// Interface de Metodos Documento Legal
    /// </summary>
    public interface IDocumentoLegalRepository : IRepositoryBase<DocumentoLegal>
    {
        /// <summary>
        /// IRepository: Farmacia Listar
        /// </summary>
        Task<ICollection<DocumentoLegal>> DocumentoLegalListar(DocumentoLegal request);
    }
}