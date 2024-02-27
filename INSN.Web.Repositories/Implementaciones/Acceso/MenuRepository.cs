using Dapper;
using INSN.Web.DataAccess;
using INSN.Web.Entities.SegApp;
using INSN.Web.Repositories.Interfaces.Acceso;
using Microsoft.EntityFrameworkCore;

namespace INSN.Web.Repositories.Implementaciones.Acceso
{
    /// <summary>
    /// MenuRepository
    /// </summary>
    public class MenuRepository : RepositoryBaseSegApp<Seccion>, IMenuRepository
    {
        /// <summary>
        /// Instanciar
        /// </summary>
        /// <param name="context"></param>
        public MenuRepository(SegAppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Seccion Listar
        /// <param name="request"></param>
        /// </summary>
        public async Task<ICollection<Seccion>> SeccionListar(Seccion request)
        {
            var connection = Context.Database.GetDbConnection();

            var query = await connection.QueryAsync<Seccion>("sp_Seccion_Listar", commandType: System.Data.CommandType.StoredProcedure, param: new
            {
                request.CodigoSistemaId,
                request.RolId
            });

            return query.ToList();
        }

        /// <summary>
        /// Modulo Listar
        /// <param name="request"></param>
        /// </summary>
        public async Task<ICollection<Modulo>> ModuloListar(Modulo request)
        {
            var connection = Context.Database.GetDbConnection();

            var query = await connection.QueryAsync<Modulo>("sp_Modulo_Listar", commandType: System.Data.CommandType.StoredProcedure, param: new
            {
                request.CodigoSeccionId,
                request.RolId
            });

            return query.ToList();
        }
    }
}