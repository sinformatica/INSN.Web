using INSN.Web.Common;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Util;
using INSN.Web.Portal.Services.Interfaces.Util;
using System.Net.Http.Headers;

namespace INSN.Web.Portal.Services.Implementaciones.Util
{
    /// <summary>
    /// Proxy: Correo Credencial Proxy
    /// </summary>
    public class CorreoCredencialProxy : CrudRestHelperBase<CorreoCredencialDtoResponse, CorreoCredencialDtoResponse>, ICorreoCredencialProxy
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;

        /// <summary>
        /// Inicializar
        /// <param name="httpClient"></param>
        /// <param name="httpContextAccessor"></param>
        /// </summary>
        public CorreoCredencialProxy(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            : base("api/Util/CorreoCredencial", httpClient)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

            // Configurar la cabecera de autorización con el token
            string token = _httpContextAccessor?.HttpContext?.Session.GetString(Constantes.JwtToken) ?? string.Empty;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        /// <summary>
        /// Proxy: Obtener Correo Credencial
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<CorreoCredencialDtoResponse> ObtenerCorreoCredencial()
        {
            var response = await HttpClient.GetFromJsonAsync<BaseResponseGeneric<CorreoCredencialDtoResponse>>($"{BaseUrl}/ObtenerCorreoCredencial");
            if (response!.Success)
            {
                return response.Data!;
            }

            throw new InvalidOperationException(response.ErrorMessage);
        }
    }
}