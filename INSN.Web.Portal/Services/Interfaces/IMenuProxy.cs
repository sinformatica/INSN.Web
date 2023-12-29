using INSN.Web.Models.Response.Sistemas;
using INSN.Web.Models;
using INSN.Web.Models.Response.Sistema;
using INSN.Web.Models.Request.Sistema;

namespace INSN.Web.Portal.Services.Interfaces
{
    /// <summary>
    /// Interface Proxy Menu
    /// </summary>
    public interface IMenuProxy
    {
        /// <summary>
        /// IProxy: Seccion Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<SeccionDtoResponse>> SeccionListar(SeccionDtoRequest request);

        /// <summary>
        /// IProxy: Modulo Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<ModuloDtoResponse>> ModuloListar(ModuloDtoRequest request);
    }
}
