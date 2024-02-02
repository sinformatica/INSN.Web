using INSN.Web.Models.Response.Sistemas;

namespace INSN.Web.Portal.Services.Interfaces.SegApp
{
    /// <summary>
    /// ISistemaProxy
    /// </summary>
    public interface ISistemaProxy
    {
        /// <summary>
        /// IProxy: Sistema Listar
        /// </summary>
        /// <returns></returns>
        Task<ICollection<SistemaDtoResponse>> SistemaListar();
    }
}