using INSN.Web.Models.Response;
using INSN.Web.Models;
using INSN.Web.Portal.Services.Interfaces;

namespace INSN.Web.Portal.Services.Implementaciones
{
    /// <summary>
    /// Clase Proxy Usuario
    /// </summary>
    public class UsuarioProxy : RestBase, IUsuarioProxy
    {
        /// <summary>
        /// Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        public UsuarioProxy(HttpClient httpClient)
            : base("api/Usuario", httpClient)
        {

        }

        /// <summary>
        /// Proxy: Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LoginDtoResponse> Login(LoginDtoRequest request)
        {
            return await SendAsync<LoginDtoRequest, LoginDtoResponse>(request, HttpMethod.Post, "Login");
        }

        //public async Task<BaseResponse> RegisterAsync(RegisterDtoRequest request)
        //{
        //    return await SendAsync<RegisterDtoRequest, BaseResponse>(request, HttpMethod.Post, "Register");
        //}
    }
}
