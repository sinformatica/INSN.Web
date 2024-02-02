using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Sistemas;
using INSN.Web.Models.Response.Acceso;
using INSN.Web.Models.Request.Acceso;

namespace INSN.Web.Services.Interfaces.Acceso
{
    /// <summary>
    /// IAccesoService
    /// </summary>
    public interface IAccesoService
    {
        /// <summary>
        /// IService: Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginDtoResponse> Login(LoginDtoRequest request);

        /// <summary>
        /// IService: Sistemas Por Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<SistemaDtoResponse>>> SistemasPorUsuarioListar(LoginUsuarioDtoRequest request);

        /// <summary>
        /// IService: Login Sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginDtoResponse> LoginSistema(LoginSistemaDtoRequest request);
    }
}