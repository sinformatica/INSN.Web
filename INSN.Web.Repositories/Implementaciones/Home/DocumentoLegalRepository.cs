using Dapper;
using INSN.Web.DataAccess;
using INSN.Web.Entities.DocumentoLegal;
using INSN.Web.Repositories.Interfaces.Home;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace INSN.Web.Repositories.Implementaciones.Home
{
    /// <summary>
    /// Metodos de Documento Legal 
    /// </summary>
    public class DocumentoLegalRepository : RepositoryBase<DocumentoLegal>, IDocumentoLegalRepository
    {
        /// <summary>
        /// INSNWebDBContext
        /// </summary>
        /// <param name="context"></param>
        public DocumentoLegalRepository(INSNWebDBContext context) : base(context)
        {
        }

        /// <summary>
        /// Repository: Documento Legal Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<DocumentoLegal>> DocumentoLegalListar(DocumentoLegal request)
        {
            try
            {
                Expression<Func<DocumentoLegal, bool>> predicate =
                    x => x.Descripcion.Contains(request.Descripcion ?? string.Empty)
                     && (request.Area == null || x.Area == request.Area)
                         && (request.Estado == null || x.Estado == request.Estado)
                         && (request.CodigoTipoDocumentoId == null || x.CodigoTipoDocumentoId == request.CodigoTipoDocumentoId)
                         && (x.EstadoRegistro == request.EstadoRegistro);
     
                return await Context.Set<DocumentoLegal>()
                    .Where(predicate)
                    .Select(p => new DocumentoLegal
                    {
                        CodigoDocumentoLegalId = p.CodigoDocumentoLegalId,
                        Documento = p.Documento,
                        Descripcion = p.Descripcion,
                        CodigoTipoDocumentoId = p.CodigoTipoDocumentoId,
                        FechaPublicacion = p.FechaPublicacion,
                        PDF = p.PDF,
                        Estado = p.Estado,
                        EstadoRegistro = p.EstadoRegistro
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }
    }
}
