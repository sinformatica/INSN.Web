using INSN.Web.Models.Response;
using INSN.Web.Models;

namespace INSN.Web.Portal.Services.Interfaces
{
    public interface IUserProxy
    {
        Task<LoginDtoResponse> Login(LoginDtoRequest request);

        //Task<BaseResponse> RegisterAsync(RegisterDtoRequest request);
    }
}
