using INSN.Web.DataAccess;
using INSN.Web.Entities.SegApp;
using INSN.Web.Repositories.Interfaces.SegApp;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Implementaciones.SegApp
{
    /// <summary>
    /// SistemaRepository
    /// </summary>
    public class SistemaRepository : RepositoryBaseSegAppEF<Sistema>, ISistemaRepository
    {
        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="context"></param>
        public SistemaRepository(SegAppDbContextEF context) : base(context)
        {
        }

        /// <summary>
        /// Repository: Sistema Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<Sistema>> SistemaListar()
        {
            Expression<Func<Sistema, bool>> predicate = x => (x.Estado == "A" && x.EstadoRegistro == 1);

            return await Context.Set<Sistema>()
                .Where(predicate)
                .Select(p => new Sistema
                {
                    CodigoSistemaId = p.CodigoSistemaId,
                    Descripcion = p.Descripcion,
                    Estado = p.Estado
                })
                .OrderBy(s => s.Descripcion)
                .ToListAsync();
        }
    }
}