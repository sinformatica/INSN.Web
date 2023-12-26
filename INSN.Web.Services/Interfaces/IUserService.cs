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
        Task<LoginDtoResponse> Login(LoginDtoRequest request);
        Task<ListaSistemasDtoResponse> SistemasPorUsuarioListar(LoginUsuarioDtoRequest usuario);
        Task<LoginDtoResponse> LoginSistema(LoginSistemaDtoRequest request);
        Task<BaseResponse> UsuarioInsertar(UsuarioDtoRequest request);
        Task<BaseResponse> RolInsertar(string nombreRol);
        Task<BaseResponse> RolesUsuarioAsignar(UsuarioRolDtoRequest request);
    }
}
