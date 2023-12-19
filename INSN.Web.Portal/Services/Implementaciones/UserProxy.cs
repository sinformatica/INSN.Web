using INSN.Web.Models.Response;
using INSN.Web.Models;
using INSN.Web.Portal.Services.Interfaces;

namespace INSN.Web.Portal.Services.Implementaciones
{
    public class UserProxy : RestBase, IUserProxy
    {
        public UserProxy(HttpClient httpClient)
            : base("api/Users", httpClient)
        {

        }

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
