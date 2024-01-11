using Dapper;
using INSN.Web.DataAccess;
using INSN.Web.Entities.SegApp;
using INSN.Web.Models.Request.Sistema;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Sistema;
using INSN.Web.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Implementaciones
{
    /// <summary>
    /// Repository Menu
    /// </summary>
    public class MenuRepository : RepositoryBaseSegApp<Seccion>, IMenuRepository
    {
        public MenuRepository(SegAppDbContext context)
        : base(context)
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
                CodigoSistemaId = request.CodigoSistemaId,
                RolId = request.RolId
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
                CodigoSeccionId = request.CodigoSeccionId,
                RolId = request.RolId
            });

            return query.ToList();
        }
    }
}