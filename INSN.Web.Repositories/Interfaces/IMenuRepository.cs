using INSN.Web.Models.Request.Sistema;
using INSN.Web.Models.Response.Sistema;
using INSN.Web.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Entities;

namespace INSN.Web.Repositories.Interfaces
{
    /// <summary>
    /// Interface Repository Menu
    /// </summary>
    public interface IMenuRepository : IRepositoryBaseSegApp<Seccion>
    {
        /// <summary>
        /// Seccion Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<Seccion>> SeccionListar(Seccion request);

        /// <summary>
        /// Modulo Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<Modulo>> ModuloListar(Modulo request);
    }
}
