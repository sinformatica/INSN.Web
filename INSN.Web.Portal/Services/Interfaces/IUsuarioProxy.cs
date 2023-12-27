using INSN.Web.Models.Response;
using INSN.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Services.Interfaces
{
    /// <summary>
    /// Interface Proxy Usuario
    /// </summary>
    public interface IUsuarioProxy
    {
        /// <summary>
        /// IProxy: Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginDtoResponse> Login(LoginDtoRequest request);

        //Task<BaseResponse> RegisterAsync(RegisterDtoRequest request);
    }
}
