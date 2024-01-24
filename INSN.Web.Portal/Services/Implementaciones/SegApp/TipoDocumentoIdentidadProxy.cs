using INSN.Web.Common;
using INSN.Web.Models.Request;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response.SegApp;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.Portal.Services.Interfaces.SegApp;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace INSN.Web.Portal.Services.Implementaciones.SegApp
{
    public class TipoDocumentoIdentidadProxy : CrudRestHelperBase<TipoDocumentoIdentidadDtoRequest, TipoDocumentoIdentidadDtoResponse>, ITipoDocumentoIdentidadProxy
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Proxy
        /// </summary>
        /// <param name="httpClient"></param>
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
