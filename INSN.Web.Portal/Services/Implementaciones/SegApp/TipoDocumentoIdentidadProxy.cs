using INSN.Web.Common;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp;
using INSN.Web.Portal.Services.Interfaces.SegApp;
using System.Net.Http.Headers;

namespace INSN.Web.Portal.Services.Implementaciones.SegApp
{
    /// <summary>
    /// TipoDocumentoIdentidadProxy
    /// </summary>
    public class TipoDocumentoIdentidadProxy : CrudRestHelperBase<TipoDocumentoIdentidadDtoRequest, TipoDocumentoIdentidadDtoResponse>, ITipoDocumentoIdentidadProxy
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="httpContextAccessor"></param>
        public TipoDocumentoIdentidadProxy(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        : base("api/SegApp/TipoDocumentoIdentidad", httpClient)
        {
            _httpContextAccessor = httpContextAccessor;

            // Configurar la cabecera de autorización con el token
            string token = _httpContextAccessor.HttpContext.Session.GetString(Constantes.JwtToken);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        /// <summary>
        /// Proxy: Tipo Documento Identidad Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<TipoDocumentoIdentidadDtoResponse>> TipoDocumentoIdentidadListar(TipoDocumentoIdentidadDtoRequest request)
        {
            try
            {
                var response = await HttpClient.GetAsync($"{BaseUrl}/TipoDocumentoIdentidadListar");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<TipoDocumentoIdentidadDtoResponse>>>();

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
}