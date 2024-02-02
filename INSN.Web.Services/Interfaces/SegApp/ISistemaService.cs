using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Sistemas;

namespace INSN.Web.Services.Interfaces.SegApp
{
    /// <summary>
    /// ISistemaService
    /// </summary>
    public interface ISistemaService
    {
        /// <summary>
        /// Sistema Listar
        /// </summary>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<SistemaDtoResponse>>> SistemaListar();
    }
}