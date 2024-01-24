using INSN.Web.DataAccess;
using INSN.Web.Entities.SegApp;
using INSN.Web.Repositories.Interfaces.SegApp;
using INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Implementaciones
{
    /// <summary>
    /// Metodos de Tipo Documento Identidad
    /// </summary>
    public class TipoDocumentoIdentidadRepository : RepositoryBaseSegAppEF<TipoDocumentoIdentidad>, ITipoDocumentoIdentidadRepository
    {
        /// <summary>
        /// {
        /// </summary>
        /// <param name="context"></param>
        public TipoDocumentoIdentidadRepository(SegAppDbContextEF context) : base(context)
        {
        }

        /// <summary>
        /// Repository: Tipo Documento Identidad Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<TipoDocumentoIdentidad>> TipoDocumentoIdentidadListar()
        {
            Expression<Func<TipoDocumentoIdentidad, bool>> predicate = x => (x.Estado == "A" && x.EstadoRegistro == 1);

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
