using INSN.Web.Models;
using INSN.Web.Models.Response.Sistemas;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Services.Interfaces
{
    /// <summary>
    /// Interface Proxy Sistema
    /// </summary>
    public interface ISistemaProxy
    {
        /// <summary>
        /// IProxy: Sistemas Por Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<SistemaDtoResponse>> SistemasPorUsuarioListar(LoginUsuarioDtoRequest request);
    }
}
