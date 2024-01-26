using INSN.Web.DataAccess;
using INSN.Web.Entities.Mantenimiento.DocumentoInstitucional;
using INSN.Web.Repositories.Interfaces.Mantenimiento.DocumentoInstitucional;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Implementaciones.Mantenimiento.DocumentoInstitucional
{
    /// <summary>
    /// Metodos de TipoDocumento 
    /// </summary>
    public class TipoDocumentoRepository : RepositoryBase<TipoDocumento>, ITipoDocumentoRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public TipoDocumentoRepository(INSNWebDBContext context) : base(context)
        {
        }

        /// <summary>
        /// Repository: TIpo Documento Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<TipoDocumento>> TipoDocumentoListar(TipoDocumento request)
        {
            Expression<Func<TipoDocumento, bool>> predicate =
                            x => x.Area.Contains(request.Area ?? string.Empty)
                            && (request.Estado == null || x.Estado == request.Estado) &&
                            x.EstadoRegistro == request.EstadoRegistro;

            return await Context.Set<TipoDocumento>()
                .Where(predicate)
                .Select(p => new TipoDocumento
                {
                    CodigoTipoDocumentoId = p.CodigoTipoDocumentoId,
                    Area = p.Area,
                    Descripcion = p.Descripcion,
                    Estado = p.Estado,
                    EstadoRegistro = p.EstadoRegistro

                })
                .ToListAsync();
        }
    }
}
