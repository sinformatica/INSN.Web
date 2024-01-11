using INSN.Web.Entities;
using INSN.Web.Entities.SegApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Interfaces.SegApp
{
    /// <summary>
    /// Interface Repository Sistema
    /// </summary>
    public interface ISistemaRepository : IRepositoryBaseSegAppEF<Sistema>
    {
        /// <summary>
        /// IRepository: Sistema
        /// </summary>
        Task<ICollection<Sistema>> SistemaListar();
    }
}
