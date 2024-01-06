using INSN.Web.DataAccess;
using INSN.Web.Entities.Info.Mantenimiento;
using INSN.Web.Entities.SegApp;
using INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Implementaciones.SegApp.Mantenimiento
{
    /// <summary>
    /// Metodos de Usuario Rol
    /// </summary>
    public class UsuarioRolRepository : RepositoryBaseSegAppEF<UsuarioRol>, IUsuarioRolRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UsuarioRolRepository(SegAppDbContextEF context) : base(context)
        {
        }

        /// <summary>
        /// Repository: Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<UsuarioRolInfo>> UsuarioRolListar(UsuarioRol request)
        {
            Expression<Func<UsuarioRol, bool>> predicate =
                                x => x.UserId == request.UserId
                                    && (request.Estado == null || x.Estado == request.Estado);

            return await Context.Set<UsuarioRol>()
                .Where(predicate)
                .Select(p => new UsuarioRolInfo
                {
                    RoleId = p.RoleId,
                    NombreRol = p.Rol.Name,
                    CodigoSistemaId = p.CodigoSistemaId,
                    NombreSistema = p.Sistema.Descripcion,
                    Estado = p.Estado
                })
                .ToListAsync();
        }
    }
}
