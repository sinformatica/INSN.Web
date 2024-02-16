using INSN.Web.DataAccess;
using INSN.Web.Entities.Util;
using INSN.Web.Repositories.Interfaces.Util;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Implementaciones.Util
{
    /// <summary>
    /// Correo Credenciales Repository
    /// </summary>
    public class CorreoCredencialesRepository : RepositoryBase<CorreoCredenciales>, ICorreoCredencialesRepository
    {
        /// <summary>
        /// Inicializar
        /// <param name="context"></param>
        /// </summary>
        public CorreoCredencialesRepository(INSNWebDBContext context) : base(context)
        {
        }

        /// <summary>
        /// Obtener Correo Credenciales
        /// </summary>
        public async Task<CorreoCredenciales> ObtenerCorreoCredenciales()
        {
            return await Context.DbSetCorreoCredenciales?.FirstOrDefaultAsync();
        }
    }
}
