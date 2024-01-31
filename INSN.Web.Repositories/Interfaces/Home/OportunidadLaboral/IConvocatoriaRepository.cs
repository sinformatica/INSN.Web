using INSN.Web.Entities.Home.OportunidadLaboral;
using INSN.Web.Entities.Info.Home.OportunidadLaboral;

namespace INSN.Web.Repositories.Interfaces.Home.OportunidadLaboral
{
    /// <summary>
    /// Interface de Metodos Documento Legal
    /// </summary>
    public interface IConvocatoriaRepository : IRepositoryBase<DocumentoConvocatoria>
    {
        /// <summary>
        /// IRepository: Farmacia Listar
        /// </summary>
        Task<ICollection<DocumentoConvocatoriaInfo>> DocumentoConvocatoriaListar(Convocatoria request);
    }
}