using INSN.Web.Models.Request.Acceso;
using INSN.Web.Models.Response.Acceso;

namespace INSN.Web.Portal.Services.Interfaces.Acceso
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
