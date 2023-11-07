using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home;

namespace INSN.Web.Services.Interfaces.Home
{
    /// <summary>
    /// Interface Servicio Tipo Documento
    /// </summary>
    public interface ITipoDocumentoService
    {
        /// <summary>
        /// Interface de Listar Tipo Documento
        /// </summary>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<TipoDocumentoDtoResponse>>> ListAsync();
    }
}