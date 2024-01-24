using INSN.Web.Models;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Response.Sistemas;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Services.Interfaces.SegApp
{
    /// <summary>
    /// Interface Proxy Sistema
    /// </summary>
    public interface ISistemaProxy
    {
        /// <summary>
        /// IProxy: Sistema Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<SistemaDtoResponse>> SistemaListar();
    }
}
