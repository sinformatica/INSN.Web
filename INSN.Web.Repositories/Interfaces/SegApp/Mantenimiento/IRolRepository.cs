using INSN.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento
{
    /// <summary>
    /// Intarface de Metodos Rol
    /// </summary>
    public interface IRolRepository : IRepositoryBaseSegApp<Rol>
    {
        /// <summary>
        /// IRepository: Rol Listar
        /// </summary>
        Task<ICollection<Rol>> RolListar(Rol request);
    }
}
