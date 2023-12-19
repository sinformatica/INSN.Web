using INSN.Web.Models.Response;
using INSN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Models.Request.SegApp;

namespace INSN.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginDtoResponse> LoginAsync(LoginDtoRequest request);
        Task<BaseResponse> RegistrarUsuarioAsync(UsuarioDtoRequest request);
        Task<BaseResponse> RegistrarRolAsync(string nombreRol);
        Task<BaseResponse> AsignarRolesUsuarioAsync(UsuarioRolDtoRequest request);
    }
}
