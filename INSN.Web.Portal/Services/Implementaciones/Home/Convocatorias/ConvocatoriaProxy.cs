using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home.Convocatorias;
using INSN.Web.Portal.Services.Interfaces.Home.Convocatorias;

namespace INSN.Web.Portal.Services.Implementaciones.Home.OportunidadLaboral;

/// <summary>
/// Convocatoria Proxy
/// </summary>
public class ConvocatoriaProxy : CrudRestHelperBase<ConvocatoriaDtoRequest, ConvocatoriaDtoResponse>, IConvocatoriaProxy
{
    /// <summary>
    /// Convocatoria Proxy
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="httpContextAccessor"></param>
    public ConvocatoriaProxy(HttpClient httpClient, IHttpContextAccessor? httpContextAccessor)
        : base("api/Mantenimiento/Convocatoria", httpClient)
    {
    }

    #region[Convocatoria Tipo]
    /// <summary>
    /// Proxy: Convocatoria Tipo Listar
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<ICollection<ConvocatoriaTipoDtoResponse>> ConvocatoriaTipoListar()
    {
        try
        {
            var response = await HttpClient.GetAsync($"{BaseUrl}/ConvocatoriaTipoListar");
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<BaseResponseGeneric<ICollection<ConvocatoriaTipoDtoResponse>>>();

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
    #endregion

    #region[Convocatoria]
    /// <summary>
    /// Proxy: Convocatoria Listar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<ICollection<ConvocatoriaDtoResponse>> ConvocatoriaListar(ConvocatoriaDtoRequest request)
    {
        try
        {
            var queryString = $"?Descripcion={request.Descripcion}&CodigoConvocatoriaTipoId={request.CodigoConvocatoriaTipoId}&Estado={request.Estado}&EstadoRegistro={request.EstadoRegistro}";
            var response = await HttpClient.GetAsync($"{BaseUrl}/ConvocatoriaListar{queryString}");

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
    #endregion

    #region[Convocatoria Detalle]
    /// <summary>
    ///  Proxy: Convocatoria Detalle Listar
    /// </summary>
    /// <param name="CodigoConvocatoriaId"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<ICollection<ConvocatoriaDetalleDtoResponse>> ConvocatoriaDetalleListar(int CodigoConvocatoriaId)
    {
        try
        {
            var response = await HttpClient.GetAsync($"{BaseUrl}/ConvocatoriaDetalleListar/{CodigoConvocatoriaId}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<BaseResponseGeneric<ICollection<ConvocatoriaDetalleDtoResponse>>>();

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
    #endregion
}