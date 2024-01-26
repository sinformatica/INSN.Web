using INSN.Web.Models.Response;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home.OportunidadLaboral;

namespace INSN.Web.Services.Interfaces.Home.OportunidadLaboral
{
    /// <summary>
    /// Interface Servicio Convocatoria
    /// </summary>
    public interface IDocumentoConvocatoriaService
    {
        /// <summary>
        /// Documento Convocatoria Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<DocumentoConvocatoriaDtoResponse>>> DocumentoConvocatoriaListar(ConvocatoriaDtoRequest request);
    }
}