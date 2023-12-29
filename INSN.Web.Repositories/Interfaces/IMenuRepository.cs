using INSN.Web.Models.Request.Sistema;
using INSN.Web.Models.Response.Sistema;
using INSN.Web.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Interfaces
{
    /// <summary>
    /// Interface Repository Menu
    /// </summary>
    public interface IMenuRepository
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
