using INSN.Web.Models;

namespace INSN.Web.Portal.Services.Interfaces
{
    /// <summary>
    /// Interface Proxy Redireccionar
    /// </summary>
    public interface IRedireccionarProxy
    {
        /// <summary>
        /// IProxy: Login Sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginDtoResponse> LoginSistema(LoginSistemaDtoRequest request);
    }
}
