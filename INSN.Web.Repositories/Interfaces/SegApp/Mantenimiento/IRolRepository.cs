using INSN.Web.Entities.SegApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento
{
    /// <summary>
    /// Interface de Metodos Rol
    /// </summary>
    public interface IRolRepository : IRepositoryBaseSegAppEF<Rol>
    {
        /// <summary>
        /// IRepository: Rol Listar
        /// </summary>
        Task<ICollection<Rol>> RolListar(Rol request);

        /// <summary>
        /// IRepository: Rol Por Sistema Listar
        /// </summary>
        Task<ICollection<Rol>> RolPorSistemaListar(int CodigoSistemaId);
    }
}
