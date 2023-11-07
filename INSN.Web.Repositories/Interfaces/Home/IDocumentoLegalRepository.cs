using INSN.Web.Entities.DocumentoLegal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Interfaces.Home
{
    /// <summary>
    /// Intarface de Metodos Documento Legal
    /// </summary>
    public interface IDocumentoLegalRepository : IRepositoryBase<DocumentoLegal>
    {
        Task<ICollection<DocumentoLegal>> ListAsync(string? Documento);
    }
}
