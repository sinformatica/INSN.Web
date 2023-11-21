using INSN.Web.Models.Request;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home;
using INSN.Web.Portal.Services.Interfaces.Home.DirectorioInstitucional;

namespace INSN.Web.Portal.Services.Implementaciones.Home.DirectorioInstitucional;

public class DocumentoLegalProxy : CrudRestHelperBase<DocumentoLegalDtoRequest, DocumentoLegalDtoResponse>, IDocumentoLegalProxy
{
    public DocumentoLegalProxy(HttpClient httpClient)
        : base("api/DocumentoLegal", httpClient)
    {
    }

    public async Task<PaginationResponse<DocumentoLegalDtoResponse>> ListAsync(BusquedaDocumentoLegalRequest request)
    {
        var response = await HttpClient.GetFromJsonAsync<PaginationResponse<DocumentoLegalDtoResponse>>(
            $"{BaseUrl}?Documento={request.Documento}&Descripcion={request.Descripcion}&TipoDocumentoId={request.TipoDocumentoId}&estado={request.Estado}&page={request.Page}&rows={request.Rows}");

        if (response is { Success: true })
        {
            return response;
        }

        return await Task.FromResult(new PaginationResponse<DocumentoLegalDtoResponse>());
    }
}