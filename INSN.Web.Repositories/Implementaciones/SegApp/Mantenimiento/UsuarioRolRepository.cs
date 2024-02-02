using INSN.Web.DataAccess;
using INSN.Web.Entities.Info.Mantenimiento;
using INSN.Web.Entities.SegApp;
using INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Implementaciones.SegApp.Mantenimiento
{
    /// <summary>
    /// UsuarioRolRepository
    /// </summary>
    public class UsuarioRolRepository : RepositoryBaseSegAppEF<UsuarioRol>, IUsuarioRolRepository
    {
        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="context"></param>
        public UsuarioRolRepository(SegAppDbContextEF context) : base(context)
        {
        }

        /// <summary>
        /// Repository: Usuario Listar
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<ICollection<UsuarioRolInfo>> UsuarioRolListar(string UserId)
        {
            Expression<Func<UsuarioRol, bool>> predicate = x => x.UserId == UserId
                                        && (x.Estado == "A" || x.Estado == null);

            return await Context.Set<UsuarioRol>()
                .Where(predicate)
                .Select(p => new UsuarioRolInfo
                {
                    CodigoUsuarioRolId = p.CodigoUsuarioRolId,
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