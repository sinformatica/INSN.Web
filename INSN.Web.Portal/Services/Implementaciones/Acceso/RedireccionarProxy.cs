using INSN.Web.Common;
using INSN.Web.Models.Request.Acceso;
using INSN.Web.Models.Response.Acceso;
using INSN.Web.Portal.Services.Interfaces.Acceso;
using System.Net.Http.Headers;

namespace INSN.Web.Portal.Services.Implementaciones.Acceso
{
    /// <summary>
    /// Clase Proxy Redireccionar
    /// </summary>
    public class RedireccionarProxy : RestBase, IRedireccionarProxy
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        public RedireccionarProxy(HttpClient httpClient, IHttpContextAccessor httpContextAccessor) 
            : base("api/Acceso/Acceso", httpClient)
        {
            _httpContextAccessor = httpContextAccessor;

            // Configurar la cabecera de autorización con el token
            string token = _httpContextAccessor.HttpContext.Session.GetString(Constantes.JwtToken);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        /// <summary>
        /// Proxy: Login Sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LoginDtoResponse> LoginSistema(LoginSistemaDtoRequest request)
        {
            return await SendAsync<LoginSistemaDtoRequest, LoginDtoResponse>(request, HttpMethod.Post, "LoginSistema");
        }
    }
}