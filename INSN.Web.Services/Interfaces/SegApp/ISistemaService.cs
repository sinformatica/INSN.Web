using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Sistemas;

namespace INSN.Web.Services.Interfaces.SegApp
{
    public interface ISistemaService
    {
        /// <summary>
        /// Sistema Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<SistemaDtoResponse>>> SistemaListar();
    }
}