using INSN.Web.Entities.Mantenimiento.Comunicado;
using INSN.Web.Entities.SegApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Interfaces.Mantenimiento.Comunicados
{
    /// <summary>
    /// Interface de Metodos Comunicado
    /// </summary>
    public interface IComunicadoRepository : IRepositoryBase<Comunicado>
    {
        /// <summary>
        /// IRepository: Comunicado Listar
        /// </summary>
        Task<ICollection<Comunicado>> ComunicadoListar(Comunicado request);
    }
}
