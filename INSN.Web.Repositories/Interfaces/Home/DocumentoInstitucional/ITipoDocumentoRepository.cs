using INSN.Web.Entities.DocumentoInstitucional;

namespace INSN.Web.Repositories.Interfaces.Home.DocumentoInstitucional
{
    /// <summary>
    /// Interface de Metodos Tipo Documento
    /// </summary>
    public interface ITipoDocumentoRepository : IRepositoryBase<TipoDocumento>
    {
        /// <summary>
        /// IRepository: TipoDocumento Listar
        /// </summary>
        Task<ICollection<TipoDocumento>> TipoDocumentoListar(TipoDocumento request);
    }
}