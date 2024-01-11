using INSN.Web.DataAccess;
using INSN.Web.Entities.DocumentoLegal;
using INSN.Web.Repositories.Interfaces.Home;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Implementaciones.Home
{
    /// <summary>
    /// Metodos de TipoDocumento 
    /// </summary>
    public class TipoDocumentoRepository : RepositoryBase<TipoDocumento>, ITipoDocumentoRepository
    {
        public TipoDocumentoRepository(INSNWebDBContext context) : base(context)
        {

        }

        /// <summary>
        /// Repository: TipoDocumento Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<TipoDocumento>> ListAsync(string Area, string Estado, int EstadoRegistro)
        {
            Expression<Func<TipoDocumento, bool>> predicate =
                            x => x.Descripcion.Contains(Area ?? string.Empty)                           
                            && (Estado == null || x.Estado == Estado) &&
                            (x.EstadoRegistro == EstadoRegistro);

            return await Context.Set<TipoDocumento>()
                .Where(predicate)
                .Select(p => new TipoDocumento
                {
                    Id = p.Id,
                    Area = p.Area,
                    Descripcion = p.Descripcion
                })
                .ToListAsync();
        }
    }
}
