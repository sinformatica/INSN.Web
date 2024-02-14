using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Sistema;
using INSN.Web.Models.Request.Sistema;
using INSN.Web.Common;
using INSN.Web.Portal.Services.Interfaces.Acceso;
using System.Net.Http.Headers;

namespace INSN.Web.Portal.Services.Implementaciones.Acceso
{
    /// <summary>
    /// Clase Proxy Menu
    /// </summary>
    public class MenuProxy : RestBase, IMenuProxy
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;

        /// <summary>
        /// Menu Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="httpContextAccessor"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MenuProxy(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            : base("api/Acceso/Menu", httpClient)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

            // Configurar la cabecera de autorización con el token
            string? token = _httpContextAccessor?.HttpContext?.Session.GetString(Constantes.JwtToken);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        /// <summary>
        /// Proxy: Seccion Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<SeccionDtoResponse>> SeccionListar(SeccionDtoRequest request)
        {
            try
            {
                var queryString = $"?CodigoSistemaId={request.CodigoSistemaId}";
                queryString += $"&RolId={request.RolId}";
                var response = await HttpClient.GetAsync($"{BaseUrl}/SeccionListar{queryString}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<SeccionDtoResponse>>>();

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

        /// <summary>
        /// Proxy: Modulo Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<ModuloDtoResponse>> ModuloListar(ModuloDtoRequest request)
        {
            try
            {
                var queryString = $"?CodigoSeccionId={request.CodigoSeccionId}";
                queryString += $"&RolId={request.RolId}";
                var response = await HttpClient.GetAsync($"{BaseUrl}/ModuloListar{queryString}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<ModuloDtoResponse>>>();

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