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
        /// 
        /// </summary>
        /// <param name="Documento"></param>
        /// <param name="IdTipoDocumento"></param>
        /// <param name="Estado"></param>
        /// <param name="Page"></param>
        /// <param name="Rows"></param>
        /// <returns></returns>
        Task<PaginationResponse<DocumentoLegalDtoResponse>> ListAsync(string? Documento, int? IdTipoDocumento,
            string? Estado, int Page, int Rows);
    }
}