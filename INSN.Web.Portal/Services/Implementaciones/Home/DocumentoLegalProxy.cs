using INSN.Web.Models.Request;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home;
using INSN.Web.Portal.Services.Interfaces;
namespace INSN.Web.Portal.Services.Implementaciones;

public class DocumentoLegalProxy : CrudRestHelperBase<DocumentoLegalDtoRequest, DocumentoLegalDtoResponse>, IDocumentoLegalProxy
{
    public DocumentoLegalProxy(HttpClient httpClient) 
        : base("api/DocumentoLegal", httpClient)
    {
    }

    public async Task<PaginationResponse<DocumentoLegalDtoResponse>> ListAsync(BusquedaDocumentoLegalRequest request)
    {
        var response = await HttpClient.GetFromJsonAsync<PaginationResponse<DocumentoLegalDtoResponse>>(
            $"{BaseUrl}?filter={request.Filter}&idTipoDocumento={request.IdTipoDocumento}&estado={request.Estado}&page={request.Page}&rows={request.Rows}");

        if (response is { Success: true })
        {
            return response;
        }

        return await Task.FromResult(new PaginationResponse<DocumentoLegalDtoResponse>());
    }
}