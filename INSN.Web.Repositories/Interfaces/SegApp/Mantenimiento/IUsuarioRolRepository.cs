using INSN.Web.Entities.Info.Mantenimiento;
using INSN.Web.Entities.SegApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento
{
    public interface IUsuarioRolRepository : IRepositoryBaseSegAppEF<UsuarioRol>
    {
        /// <summary>
        /// IRepository: Usuario Rol Listar
        /// </summary>
        Task<ICollection<UsuarioRolInfo>> UsuarioRolListar(UsuarioRol request);
    }
}
