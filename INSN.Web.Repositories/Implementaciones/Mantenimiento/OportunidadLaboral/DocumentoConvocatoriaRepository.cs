using INSN.Web.DataAccess;
using INSN.Web.Entities.Info.Home.OportunidadLaboral;
using INSN.Web.Entities.Mantenimiento.OportunidadLaboral;
using INSN.Web.Repositories.Interfaces.Mantenimiento.OportunidadLaboral;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Implementaciones.Mantenimiento.OportunidadLaboral
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
                             && x.EstadoRegistro == request.EstadoRegistro;

                return await Context.Set<DocumentoConvocatoria>()
                    .Where(predicate)
                    .Select(p => new DocumentoConvocatoriaInfo
                    {
                        CodigoConvocatoriaId = p.Convocatoria.CodigoConvocatoriaId,
                        DescripcionConvocatoria = p.Convocatoria.Descripcion,
                        FechaInicio = p.Convocatoria.FechaInicio,
                        FechaFinal = p.Convocatoria.FechaFinal,
                        Estado = p.Convocatoria.Estado,

                        CodigoTipoConvocatoriaId = p.Convocatoria.TipoConvocatoria.CodigoTipoConvocatoriaId,
                        DescripcionTipoConvocatoria = p.Convocatoria.TipoConvocatoria.Descripcion,

                        CodigoDocumentoConvocatoriaId = p.CodigoDocumentoConvocatoriaId,
                        DescripcionDocumentoConvocatoria = p.Descripcion,
                        Ruta = p.Ruta,
                        TipoArchivo = p.TipoArchivo,

                        CodigoTipoDocumentoConvocatoriaId = p.TipoDocumentoConvocatoria.CodigoTipoDocumentoConvocatoriaId,
                        DescripcionTipoDocumentoConvocatoria = p.TipoDocumentoConvocatoria.Descripcion,
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