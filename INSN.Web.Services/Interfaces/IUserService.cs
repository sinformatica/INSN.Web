using INSN.Web.Models.Response;
using INSN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginDtoResponse> LoginAsync(LoginDtoRequest request);
        Task<BaseResponse> RegisterAsync(RegisterDtoRequest request);
        Task<BaseResponse> RegistrarRolAsync(string nombreRol);
    }
}
