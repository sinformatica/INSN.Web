using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home.OportunidadLaboral;
using INSN.Web.Portal.Services.Interfaces.Home.OportunidadLaboral;

namespace INSN.Web.Portal.Services.Implementaciones.Home.OportunidadLaboral;

/// <summary>
/// Clase Proxy Documento Convocatoria
/// </summary>
public class ConvocatoriaProxy : CrudRestHelperBase<ConvocatoriaDtoRequest, ConvocatoriaDtoResponse>, IDocumentoConvocatoriaProxy
{
    /// <summary>
    /// Convocatoria Proxy
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="httpContextAccessor"></param>
    public ConvocatoriaProxy(HttpClient httpClient, IHttpContextAccessor? httpContextAccessor)
        : base("api/Consulta/OportunidadLaboral/DocumentoConvocatoria", httpClient)
    {
    }

    /// <summary>
    /// Proxy: Documento Convocatoria Listar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<ICollection<ConvocatoriaDtoResponse>> DocumentoConvocatoriaListar(ConvocatoriaDtoRequest request)
    {
        try
        {
            var queryString = $"?Descripcion={request.Descripcion}&CodigoTipoConvocatoriaId={request.CodigoTipoConvocatoriaId}&Estado={request.Estado}&EstadoRegistro={request.EstadoRegistro}";
            var response = await HttpClient.GetAsync($"{BaseUrl}/DocumentoConvocatoriaListar{queryString}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<BaseResponseGeneric<ICollection<ConvocatoriaDtoResponse>>>();

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