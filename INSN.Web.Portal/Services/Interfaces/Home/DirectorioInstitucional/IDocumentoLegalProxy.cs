using INSN.Web.Models.Request;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home;

namespace INSN.Web.Portal.Services.Interfaces.Home.DirectorioInstitucional;

public interface IDocumentoLegalProxy : ICrudRestHelper<DocumentoLegalDtoRequest, DocumentoLegalDtoResponse>
{
    Task<PaginationResponse<DocumentoLegalDtoResponse>> ListAsync(BusquedaDocumentoLegalRequest request);
}