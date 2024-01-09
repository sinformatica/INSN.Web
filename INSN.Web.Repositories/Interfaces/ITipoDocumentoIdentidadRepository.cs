using INSN.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Interfaces
{
    /// <summary>
    /// Interface de Metodos TipoDocumentoIdentidad
    /// </summary>
    public interface ITipoDocumentoIdentidadRepository : IRepositoryBaseSegAppEF<TipoDocumentoIdentidad>
    {
        /// <summary>
        /// IRepository: Tipo Documento Identidad Listar
        /// </summary>
        Task<ICollection<TipoDocumentoIdentidad>> TipoDocumentoIdentidadListar();
    }
}
