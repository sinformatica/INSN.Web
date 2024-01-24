using INSN.Web.Entities.Info.OportunidadLaboral;
using INSN.Web.Entities.OportunidadLaboral;

namespace INSN.Web.Repositories.Interfaces.Home.OportunidadLaboral
{
    /// <summary>
    /// Interface de Metodos Documento Legal
    /// </summary>
    public interface IDocumentoConvocatoriaRepository : IRepositoryBase<DocumentoConvocatoria>
    {
        /// <summary>
        /// IRepository: Farmacia Listar
        /// </summary>
        Task<ICollection<DocumentoConvocatoriaInfo>> DocumentoConvocatoriaListar(Convocatoria request);
    }
}   