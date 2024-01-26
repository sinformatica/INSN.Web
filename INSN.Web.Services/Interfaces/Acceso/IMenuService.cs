using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Sistema;
using INSN.Web.Models.Request.Sistema;

namespace INSN.Web.Services.Interfaces.Acceso
{
    /// <summary>
    /// Interface Servicio Menu
    /// </summary>
    public interface IMenuService
    {
        /// <summary>
        /// Seccion Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<SeccionDtoResponse>>> SeccionListar(SeccionDtoRequest request);

        /// <summary>
        /// Modulo Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<ModuloDtoResponse>>> ModuloListar(ModuloDtoRequest request);
    }
}
