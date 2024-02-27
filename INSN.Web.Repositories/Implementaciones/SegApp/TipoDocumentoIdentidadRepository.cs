using INSN.Web.DataAccess;
using INSN.Web.Entities.SegApp;
using INSN.Web.Repositories.Interfaces.SegApp;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Implementaciones.SegApp
{
    /// <summary>
    /// TipoDocumentoIdentidadRepository
    /// </summary>
    public class TipoDocumentoIdentidadRepository : RepositoryBaseSegAppEF<TipoDocumentoIdentidad>, ITipoDocumentoIdentidadRepository
    {
        /// <summary>
        /// Instanciar
        /// </summary>
        /// <param name="context"></param>
        public TipoDocumentoIdentidadRepository(SegAppDbContextEF context) : base(context)
        {
        }

        /// <summary>
        /// Repository: Tipo Documento Identidad Listar
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<TipoDocumentoIdentidad>> TipoDocumentoIdentidadListar()
        {
            Expression<Func<TipoDocumentoIdentidad, bool>> predicate = x => x.Estado == "A" && x.EstadoRegistro == 1;

            return await Context.Set<TipoDocumentoIdentidad>()
                .Where(predicate)
                .Select(p => new TipoDocumentoIdentidad
                {
                    Id = p.Id,
                    Descripcion = p.Descripcion,
                    Abreviatura = p.Abreviatura,
                    Estado = p.Estado
                })
                .ToListAsync();
        }
    }
}