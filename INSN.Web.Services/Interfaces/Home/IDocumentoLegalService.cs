using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response;

namespace INSN.Web.Services.Interfaces.Home
{
    /// <summary>
    /// Interface Servicio Documento Legal
    /// </summary>
    public interface IDocumentoLegalService
    {
        /// <summary>
        /// Interface de Listar Documento Legal
        /// </summary>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<DocumentoLegalDtoResponse>>> ListAsync(string? Documento);
    }
}