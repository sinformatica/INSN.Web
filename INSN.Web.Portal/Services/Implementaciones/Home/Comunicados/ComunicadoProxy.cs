using INSN.Web.Models.Request.Home.Comunicados;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home.Comunicados;
using INSN.Web.Portal.Services.Interfaces.Home.Comunicados;

namespace INSN.Web.Portal.Services.Implementaciones.Home.Comunicados
{
    /// <summary>
    /// Clase Proxy Comunicado
    /// </summary>
    public class ComunicadoProxy : CrudRestHelperBase<ComunicadoDtoRequest, ComunicadoDtoResponse>, IComunicadoProxy
    {
        /// <summary>
        /// Comunicado Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="httpContextAccessor"></param>
        public ComunicadoProxy(HttpClient httpClient, IHttpContextAccessor? httpContextAccessor)
        : base("api/Mantenimiento/Comunicado", httpClient)
        {
        }

        #region[Comunicado]
        /// <summary>
        /// Proxy: Comunicado Listar
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ICollection<ComunicadoDtoResponse>> ComunicadoListar(ComunicadoDtoRequest request)
        {
            try
            {
                var queryString = $"?Titulo={request.Titulo}&FechaExpiracion={request.FechaExpiracion.ToString("yyyy-MM-dd")}&Estado={request.Estado}&EstadoRegistro={request.EstadoRegistro}";
                var response = await HttpClient.GetAsync($"{BaseUrl}/ComunicadoListar{queryString}");
                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<ComunicadoDtoResponse>>>();

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

        #region[Comunicado Detalle]
        /// <summary>
        ///  Proxy: Comunicado Detalle Listar
        /// </summary>
        /// <param name="CodigoComunicadoId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ICollection<ComunicadoDetalleDtoResponse>> ComunicadoDetalleListar(int CodigoComunicadoId)
        {
            try
            {
                var response = await HttpClient.GetAsync($"{BaseUrl}/ComunicadoDetalleListar/{CodigoComunicadoId}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<ComunicadoDetalleDtoResponse>>>();

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
}