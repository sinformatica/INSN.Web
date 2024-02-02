using INSN.Web.Models.Response.Sistema;
using INSN.Web.Models.Request.Sistema;

namespace INSN.Web.Portal.Services.Interfaces.Acceso
{
    /// <summary>
    /// IMenuProxy
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