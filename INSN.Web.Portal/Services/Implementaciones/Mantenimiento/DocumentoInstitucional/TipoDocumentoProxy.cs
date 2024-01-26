using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Mantenimiento.DocumentoLegal;
using INSN.Web.Portal.Services.Interfaces.Mantenimiento.DocumentoInstitucional;

namespace INSN.Web.Portal.Services.Implementaciones.Mantenimiento.DocumentoInstitucional;

public class TipoDocumentoProxy : CrudRestHelperBase<TipoDocumentoDtoRequest, TipoDocumentoDtoResponse>, ITipoDocumentoProxy
{
    public TipoDocumentoProxy(HttpClient httpClient)
        : base("api/Mantenimiento/DocumentoInstitucional/TipoDocumento", httpClient)
    {
    }

    /// <summary>
    /// Proxy: Tipo Documento Listar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<ICollection<TipoDocumentoDtoResponse>> TipoDocumentoListar(TipoDocumentoDtoRequest request)
    {
        try
        {
            var queryString = $"?Descripcion={request.Descripcion}&CodigoTipoDocumentoId={request.CodigoTipoDocumentoId}&Area={request.Area}&Estado={request.Estado}&EstadoRegistro={request.EstadoRegistro}";
            var response = await HttpClient.GetAsync($"{BaseUrl}/TipoDocumentoListar{queryString}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<BaseResponseGeneric<ICollection<TipoDocumentoDtoResponse>>>();

            if (result!.Success == false)
            {
                throw new InvalidOperationException(result.ErrorMessage);
            }

            return result.Data!;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message);
        }
    }
}