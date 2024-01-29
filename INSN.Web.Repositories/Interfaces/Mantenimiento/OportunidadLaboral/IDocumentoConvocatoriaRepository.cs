using INSN.Web.Entities.Info.Home.OportunidadLaboral;
using INSN.Web.Entities.Mantenimiento.OportunidadLaboral;

namespace INSN.Web.Repositories.Interfaces.Mantenimiento.OportunidadLaboral
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