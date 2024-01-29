using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Mantenimiento.Comunicados;
using INSN.Web.Models.Request.Mantenimiento.Comunicados;

namespace INSN.Web.Services.Interfaces.Mantenimiento.Comunicados
{
    /// <summary>
    /// Interface Comunicado
    /// </summary>
    public interface IComunicadoService
    {
        /// <summary>
        /// Comunicado Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<ComunicadoDtoResponse>>> ComunicadoListar(ComunicadoDtoRequest request);
    }
}