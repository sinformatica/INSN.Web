using INSN.Web.Entities.DocumentoLegal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Interfaces.Home
{
    /// <summary>
    /// Interface de Metodos Documento Legal
    /// </summary>
    public interface IDocumentoLegalRepository : IRepositoryBase<DocumentoLegal>
    {
       // Task<ICollection<DocumentoLegal>> ListAsync(string? Documento);

        Task<ICollection<DocumentoLegal>> ListarDocumentoLegalesAsync(string Documento, int TipoDocumentoId, string Estado , int Page, int Rows);
    }
}
