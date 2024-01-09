using INSN.Web.Models.Response;
using INSN.Web.Models;
using INSN.Web.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Services.Implementaciones
{
    /// <summary>
    /// Clase Proxy Usuario
    /// </summary>
    public class AccesoProxy : RestBase, IAccesoProxy
    {
        /// <summary>
        /// Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        public AccesoProxy(HttpClient httpClient)
            : base("api/Acceso", httpClient)
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
