using INSN.Web.DataAccess;
using INSN.Web.Entities.Info.OportunidadLaboral;
using INSN.Web.Entities.OportunidadLaboral;
using INSN.Web.Repositories.Interfaces.Home.OportunidadLaboral;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Implementaciones.Home.OportunidadLaboral
{
    /// <summary>
    /// Metodos de Documento Legal 
    /// </summary>
    public class DocumentoConvocatoriaRepository : RepositoryBase<DocumentoConvocatoria>, IDocumentoConvocatoriaRepository
    {
        /// <summary>
        /// INSNWebDBContext
        /// </summary>
        /// <param name="context"></param>
        public DocumentoConvocatoriaRepository(INSNWebDBContext context) : base(context)
        {
        }


        /// <summary>
        /// Repository: Documento Convocatoria Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<DocumentoConvocatoriaInfo>> DocumentoConvocatoriaListar(Convocatoria request)
        {
            try
            {
                Expression<Func<DocumentoConvocatoria, bool>> predicate =
                             x => x.Descripcion.Contains(request.Descripcion ?? string.Empty)
                             && (request.Estado == null || x.Estado == request.Estado)
                             && (x.EstadoRegistro == request.EstadoRegistro);

                return await Context.Set<DocumentoConvocatoria>()
                    .Where(predicate)
                    .Select(p => new DocumentoConvocatoriaInfo
                    {
                        CodigoConvocatoriaId = p.Convocatoria.CodigoConvocatoriaId,
                        DescripcionConvocatoria = p.Descripcion,
                        FechaInicio= p.Convocatoria.FechaInicio,
                        FechaFinal = p.Convocatoria.FechaFinal,
                        
                        CodigoDocumentoConvocatoriaId = p.CodigoDocumentoConvocatoriaId,

                        Estado = p.Convocatoria.Estado
                    })
                    .Take(1000)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }
    }
}