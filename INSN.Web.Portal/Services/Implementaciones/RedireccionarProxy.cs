using INSN.Web.Models;
using INSN.Web.Portal.Services.Interfaces;

namespace INSN.Web.Portal.Services.Implementaciones
{
    /// <summary>
    /// Clase Proxy Redireccionar
    /// </summary>
    public class RedireccionarProxy : RestBase, IRedireccionarProxy
    {
        /// <summary>
        /// Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        public RedireccionarProxy(HttpClient httpClient)
            : base("api/Acceso", httpClient)
        {

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
