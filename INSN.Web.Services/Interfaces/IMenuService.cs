using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Models.Response.Sistemas;
using INSN.Web.Models.Response.Sistema;
using INSN.Web.Models.Request.Sistema;
using INSN.Web.Repositories.Interfaces;

namespace INSN.Web.Services.Interfaces
{
    /// <summary>
    /// Interface Servicio Menu
    /// </summary>
    public interface IMenuService : IMenuRepository
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
