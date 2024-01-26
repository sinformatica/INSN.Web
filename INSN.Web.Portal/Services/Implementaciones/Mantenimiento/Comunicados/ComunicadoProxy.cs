using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Request.Mantenimiento.Comunicados;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Mantenimiento.Comunicados;
using INSN.Web.Portal.Services.Interfaces.Mantenimiento.Comunicados;

namespace INSN.Web.Portal.Services.Implementaciones.Mantenimiento.Comunicados
{
    /// <summary>
    /// Clase Proxy Comunicado
    /// </summary>
    public class ComunicadoProxy : CrudRestHelperBase<ComunicadoDtoRequest, ComunicadoDtoResponse>, IComunicadoProxy
    {
        public ComunicadoProxy(HttpClient httpClient)
        : base("api/Mantenimiento/Comunicado", httpClient)
        {
        }

        #region[Comunicado]
        /// <summary>
        /// Proxy: Comunicado Listar
        /// </summary>
        /// <param name="request"></param>
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
        /// Proxy: Comunicado Detalle Listar
        /// </summary>
        /// <param name="request"></param>
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
