using INSN.Web.DataAccess;
using INSN.Web.Entities.Home.Comunicados;
using INSN.Web.Repositories.Interfaces.Home.Comunicados;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Implementaciones.Home.Comunicados
{
    /// <summary>
    /// Metodos de Comunicado
    /// </summary>
    public class ComunicadoRepository : RepositoryBase<Comunicado>, IComunicadoRepository
    {
        /// <summary>
        /// INSNWebDBContext
        /// </summary>
        /// <param name="context"></param>
        public ComunicadoRepository(INSNWebDBContext context) : base(context)
        {
        }

        #region[Comunicado]
        /// <summary>
        /// Repository: Comunicado Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<Comunicado>> ComunicadoListar(Comunicado request)
        {
            Expression<Func<Comunicado, bool>> predicate =
                    x => x.Titulo.Contains(request.Titulo ?? string.Empty)
                         && (request.FechaExpiracion == null || x.FechaExpiracion >= request.FechaExpiracion)
                         && (request.Estado == null || x.Estado == request.Estado)
                         && x.EstadoRegistro == request.EstadoRegistro;

            return await Context.Set<Comunicado>()
                .Where(predicate)
                .Select(p => new Comunicado
                {
                    CodigoComunicadoId = p.CodigoComunicadoId,
                    Titulo = p.Titulo,
                    FechaPublicacion = p.FechaPublicacion,
                    FechaExpiracion = p.FechaExpiracion,
                    RutaImagenPortada = p.RutaImagenPortada,
                    Ancho = p.Ancho,
                    Estado = p.Estado,
                    EstadoRegistro = p.EstadoRegistro
                })
                .ToListAsync();
        }
        #endregion

        #region[Comunicado detalle]
        /// <summary>
        /// Repository: Comunicado Detalle Listar
        /// </summary>
        /// <param name="CodigoComunicadoId"></param>
        /// <returns></returns>
        public async Task<ICollection<ComunicadoDetalle>> ComunicadoDetalleListar(int CodigoComunicadoId)
        {
            Expression<Func<ComunicadoDetalle, bool>> predicate =
                    x => x.CodigoComunicadoId == CodigoComunicadoId
                         && x.Estado == "A"
                         && x.EstadoRegistro == 1;

            return await Context.Set<ComunicadoDetalle>()
                .Where(predicate)
                .Select(p => new ComunicadoDetalle
                {
                    CodigoComunicadoDetalleId = p.CodigoComunicadoDetalleId,
                    CodigoComunicadoId = p.CodigoComunicadoId,
                    RutaImagen = p.RutaImagen,
                    Estado = p.Estado,
                    EstadoRegistro = p.EstadoRegistro
                })
                .ToListAsync();
        }
        #endregion
    }
}