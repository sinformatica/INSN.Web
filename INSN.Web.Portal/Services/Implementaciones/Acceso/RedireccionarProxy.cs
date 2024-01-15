using INSN.Web.Models.Request.Acceso;
using INSN.Web.Models.Response.Acceso;
using INSN.Web.Portal.Services.Interfaces.Acceso;

namespace INSN.Web.Portal.Services.Implementaciones.Acceso
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
            : base("api/Acceso/Acceso", httpClient)
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
