using INSN.Web.DataAccess;
using INSN.Web.Entities.SegApp;
using INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Implementaciones.SegApp.Mantenimiento
{
    /// <summary>
    /// UsuarioRepository
    /// </summary>
    public class UsuarioRepository : RepositoryBaseSegAppEF<Usuario>, IUsuarioRepository
    {
        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="context"></param>
        public UsuarioRepository(SegAppDbContextEF context) : base(context)
        {
        }

        /// <summary>
        /// Repository: Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<UsuarioInfo>> UsuarioListar(Usuario request)
        {
            Expression<Func<Usuario, bool>> predicate =
                                x => ((x.UserName == request.Nombres)
                                    || (x.Nombres.Contains(request.Nombres ?? string.Empty))
                                    || (request.Nombres != null &&
                                    (x.Nombres + " " + x.ApellidoPaterno + " " + x.ApellidoMaterno)
                                        .Contains(request.Nombres)))
                                    && (request.Estado == null || x.Estado == request.Estado)
                                    && (x.EstadoRegistro == 1);

            return await Context.Set<Usuario>()
                .Where(predicate)
                .Select(p => new UsuarioInfo
                {
                    Id = p.Id,
                    Nombres = p.Nombres,
                    ApellidoPaterno = p.ApellidoPaterno,
                    ApellidoMaterno = p.ApellidoMaterno,
                    Servicio = p.Servicio,
                    Telefono2 = p.Telefono2,
                    TipoDocumentoIdentidadId = p.TipoDocumentoIdentidadId,
                    AbreviaturaTipoDocumentoIdentidad = p.TipoDocumentoIdentidad.Abreviatura,
                    DocumentoIdentidad = p.DocumentoIdentidad,
                    UserName = p.UserName,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber,
                    Estado = p.Estado
                })
                .ToListAsync();
        }
    }
}