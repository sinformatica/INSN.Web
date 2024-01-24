using INSN.Web.DataAccess;
using INSN.Web.Entities;
using INSN.Web.Entities.SegApp;
using INSN.Web.Repositories.Interfaces;
using INSN.Web.Repositories.Interfaces.SegApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Implementaciones.SegApp
{
    /// <summary>
    /// Metodos de Tipo Documento Identidad
    /// </summary>
    public class SistemaRepository : RepositoryBaseSegAppEF<Sistema>, ISistemaRepository
    {
        /// <summary>
        /// {
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
