using Dapper;
using INSN.Web.DataAccess;
using INSN.Web.Entities;
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
    /// Metodos de Rol
    /// </summary>
    public class RolRepository : RepositoryBaseSegAppEF<Rol>, IRolRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public RolRepository(SegAppDbContextEF context) : base(context)
        {
        }

        /// <summary>
        /// Repository: Rol Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<Rol>> RolListar(Rol request)
        {
            Expression<Func<Rol, bool>> predicate =
                            x => x.Name.Contains(request.Name ?? string.Empty)
                            && (request.Estado == null || x.Estado == request.Estado)
                            && (x.EstadoRegistro == 1);

            return await Context.Set<Rol>()
                .Where(predicate)
                .Select(p => new Rol
                {
                    Id = p.Id,
                    Name = p.Name,
                    Estado = p.Estado
                })
                .ToListAsync();
        }

        /// <summary>
        /// Rol Por Sistema Listar
        /// <param name="request"></param>
        /// </summary>
        public async Task<ICollection<Rol>> RolPorSistemaListar(int CodigoSistemaId)
        {
            var connection = Context.Database.GetDbConnection();

            var query = await connection.QueryAsync<Rol>("sp_ModuloRol_ListarPorSistema", commandType: System.Data.CommandType.StoredProcedure, param: new
            {
                CodigoSistemaId = CodigoSistemaId
            });

            return query.ToList();
        }
    }
}
