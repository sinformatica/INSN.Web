using Dapper;
using INSN.Web.DataAccess;
using INSN.Web.Entities;
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
    public class MenuRepository : RepositoryBase<Seccion>, IMenuRepository
    {
        public MenuRepository(SegAppDbContext context)
        : base(context)
        {
        }

        public async Task<ICollection<Seccion>> SeccionListar(Seccion request)
        {
            var connection = Context.Database.GetDbConnection();

            var query = await connection.QueryAsync<Seccion>("uspListarTalleres", commandType: System.Data.CommandType.StoredProcedure, param: new
            {
                CodigoSistemaId = request.CodigoSistemaId,
                RolId = request.RolId
            });

            return query.ToList();
        }

        //public async Task<ICollection<SeccionDtoResponse>> SeccionListar(SeccionDtoRequest request)
        //{
        //    var response = new ICollection<SeccionDtoResponse>();

        //    try
        //    {
        //        var codigoSistemaIdParam = new SqlParameter("@CodigoSistemaId", request.CodigoSistemaId);
        //        var rolIdParam = new SqlParameter("@RolId", request.RolId);

        //        var query = $"EXEC sp_Seccion_Listar @CodigoSistemaId, @RolId";

        //        var secciones = _context.Seccion
        //            .FromSqlInterpolated(FormattableStringFactory.Create(query, codigoSistemaIdParam, rolIdParam))
        //            .AsEnumerable()
        //            .Select(x => new SeccionDtoResponse
        //            {
        //                CodigoSeccionId = x.CodigoSeccionId,
        //                Descripcion = x.Descripcion,
        //                Url = x.Url,
        //                Icono = x.Icono
        //            })
        //            .ToList();

        //        response.Data = secciones;
        //        response.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.ErrorMessage = "Error al listar las secciones";
        //        _logger.LogError(ex, response.ErrorMessage + ": {Message}", ex.Message);
        //    }

        //    return response;
        //}

        /// <summary>
        /// Modulo Listar
        /// <param name="request"></param>
        /// </summary>
        //public async Task<BaseResponseGeneric<ICollection<ModuloDtoResponse>>> ModuloListar(ModuloDtoRequest request)
        //{
        //    var response = new BaseResponseGeneric<ICollection<ModuloDtoResponse>>();

        //    try
        //    {
        //        var codigoSeccionIdParam = new SqlParameter("@CodigoSeccionId", request.CodigoSeccionId);
        //        var rolIdParam = new SqlParameter("@RolId", request.RolId);

        //        var query = $"EXEC sp_Modulo_Listar @CodigoSeccionId, @RolId";

        //        var modulos = _context.Modulo
        //            .FromSqlInterpolated(FormattableStringFactory.Create(query, codigoSeccionIdParam, rolIdParam))
        //            .AsEnumerable()
        //            .Select(x => new ModuloDtoResponse
        //            {
        //                CodigoModuloId = x.CodigoModuloId,
        //                Descripcion = x.Descripcion,
        //                Url = x.Url,
        //                Icono = x.Icono
        //            })
        //            .ToList();

        //        response.Data = modulos;
        //        response.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.ErrorMessage = "Error al listar las módulos";
        //        _logger.LogError(ex, response.ErrorMessage + ": {Message}", ex.Message);
        //    }

        //    return response;
        //}
    }
}