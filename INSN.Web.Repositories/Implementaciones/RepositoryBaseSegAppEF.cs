using INSN.Web.DataAccess;
using INSN.Web.Entities.Base;
using INSN.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Implementaciones
{
    /// <summary>
    /// Repositorio Base SegApp EF - Métodos Basicos
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryBaseSegAppEF<TEntity> : IRepositoryBaseSegAppEF<TEntity> where TEntity : AuditoriaBase
    {
        protected readonly SegAppDbContextEF Context;

        protected RepositoryBaseSegAppEF(SegAppDbContextEF context)
        {
            Context = context;
        }

        /// <summary>
        /// Repository: Listar
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<ICollection<TEntity>> Listar(Expression<Func<TEntity, bool>>? predicate = null)
        {
            var query = Context.Set<TEntity>()
                .AsQueryable();

            if (predicate is not null)
                query = query.Where(predicate);

            return await query
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Repository: Listar con predicado
        /// </summary>
        /// <typeparam name="TInfo"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <param name="relationships"></param>
        /// <returns></returns>
        public async Task<ICollection<TInfo>> Listar<TInfo>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TInfo>> selector,
            string? relationships = null)
        {
            var query = Context.Set<TEntity>()
                .Where(predicate)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(relationships))
            {
                foreach (var tabla in relationships.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(tabla);
                }
            }

            return await query
                .Select(selector)
                .ToListAsync();
        }

        /// <summary>
        /// Repository: Listar
        /// </summary>
        /// <typeparam name="TInfo"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public async Task<ICollection<TInfo>> Listar<TInfo>(Expression<Func<TEntity, TInfo>> selector)
        {
            return await Context.Set<TEntity>()
                  .AsQueryable()
                  .Select(selector)
                  .ToListAsync();
        }

        /// <summary>
        /// Repository: Listar
        /// </summary>
        /// <typeparam name="TInfo"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <param name="orderBy"></param>
        /// <param name="relationships"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public async Task<(ICollection<TInfo> Collection, int Total)> Listar<TInfo, TKey>
            (
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TInfo>> selector,
            Expression<Func<TEntity, TKey>> orderBy,
            string? relationships,
            int page, int rows)
        {
            var query = Context.Set<TEntity>()
    .Where(predicate)
    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(relationships))
            {
                foreach (var tabla in relationships.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    // Verificar si la propiedad de navegación existe en el modelo
                    var navigationProperty = typeof(TEntity).GetProperty(tabla);

                    if (navigationProperty != null && navigationProperty.PropertyType.IsClass && !navigationProperty.PropertyType.IsArray)
                    {
                        query = query.Include(tabla);
                    }
                }
            }

            var collection = await query.OrderBy(orderBy)
                .Skip((page - 1) * rows)
                .Take(rows)
                .Select(selector)
                .ToListAsync();

            var total = await Context.Set<TEntity>()
                .Where(predicate)
                .CountAsync();

            return (collection, total);
        }

        /// <summary>
        /// Repository: Buscar por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity?> BuscarId(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Repository: Buscar por ID string
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity?> BuscarStringId(string id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Repository: Agregar - Registrar Nuevo Item - Registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Insertar(TEntity entity)
        {
            int respuesta = 1;
            try
            {
                await Context.Set<TEntity>().AddAsync(entity);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                respuesta = -1;
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine(innerException.Message);
                    innerException = innerException.InnerException;
                }
            }

            return respuesta;
        }

        /// <summary>
        /// Repository: Actualizar Registro - Item
        /// </summary>
        /// <returns></returns>
        public async Task Actualizar()
        {
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Repository: Actualizar determinados campos
        /// </summary>
        /// <returns></returns>
        public async Task<int> ActualizarCampos(Expression<Func<TEntity, bool>> predicate, Action<TEntity> updateAction)
        {
            var entities = await Context.Set<TEntity>().Where(predicate).ToListAsync();

            foreach (var entity in entities)
            {
                updateAction(entity);
            }

            return await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Repository: Eliminar Registro - Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task Eliminar(int id)
        {
            var entity = await BuscarId(id);
            if (entity != null)
            {
                entity.Estado = "I";
                entity.EstadoRegistro = 0;
                entity.TerminalModificacion = Environment.MachineName;
                entity.UsuarioModificacion = Environment.UserName; //Modificar por Usuario de sesion logueada
                entity.FechaModificacion = DateTime.Now;

                await Actualizar();
            }
            else
            {
                throw new InvalidOperationException($"No se encontro el registro con el id {id}");
            }
        }

        /// <summary>
        /// Repository: Eliminar Registro (string) - Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task EliminarString(string id)
        {
            var entity = await BuscarStringId(id);
            if (entity != null)
            {
                entity.Estado = "I";
                entity.EstadoRegistro = 0;
                entity.TerminalModificacion = Environment.MachineName;
                entity.UsuarioModificacion = Environment.UserName; //Modificar por Usuario de sesion logueada
                entity.FechaModificacion = DateTime.Now;

                await Actualizar();
            }
            else
            {
                throw new InvalidOperationException($"No se encontro el registro con el id {id}");
            }
        }
    }
}