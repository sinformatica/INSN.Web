using INSN.Web.Models.Response;
using INSN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Response.Sistemas;

namespace INSN.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginDtoResponse> Login(LoginDtoRequest request);
        Task<BaseResponseGeneric<ICollection<SistemasDtoResponse>>> SistemasPorUsuarioListar(LoginUsuarioDtoRequest request);
        Task<LoginDtoResponse> LoginSistema(LoginSistemaDtoRequest request);
        Task<BaseResponse> UsuarioInsertar(UsuarioDtoRequest request);
        Task<BaseResponse> RolInsertar(string nombreRol);
        Task<BaseResponse> RolesUsuarioAsignar(UsuarioRolDtoRequest request);
    }
}
