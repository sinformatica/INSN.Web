using INSN.Web.DataAccess;
using INSN.Web.Entities.DocumentoInstitucional;
using INSN.Web.Repositories.Interfaces.Home.DocumentoInstitucional;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Implementaciones.Home.DocumentoInstitucional
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
                         && (request.Area == null || x.TipoDocumento.Area == request.Area)
                         && (request.Documento == null || x.Documento == request.Documento)
                         && (request.Estado == null || x.Estado == request.Estado)
                         && (request.CodigoTipoDocumentoId == null || x.CodigoTipoDocumentoId == request.CodigoTipoDocumentoId)
                         && x.EstadoRegistro == request.EstadoRegistro;

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
