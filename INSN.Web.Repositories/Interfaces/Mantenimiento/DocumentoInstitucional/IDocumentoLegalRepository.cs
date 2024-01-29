using INSN.Web.Entities.Mantenimiento.DocumentoInstitucional;

namespace INSN.Web.Repositories.Interfaces.Mantenimiento.DocumentoInstitucional
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