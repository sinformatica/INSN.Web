﻿using Microsoft.EntityFrameworkCore;
using INSN.Web.DataAccess;
using System.Linq.Expressions;
using INSN.Web.Entities.Base;
using INSN.Web.Repositories.Interfaces;

namespace INSN.Web.Repositories.Implementaciones
{
    /// <summary>
    /// Repositorio Base - Métodos Basicos
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly INSNWebDBContext Context;

        protected RepositoryBase(INSNWebDBContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Listar
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? predicate = null)
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
        /// Listar con predicado
        /// </summary>
        /// <typeparam name="TInfo"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <param name="relationships"></param>
        /// <returns></returns>
        public async Task<ICollection<TInfo>> ListAsync<TInfo>(
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
        /// Buscar por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Agregar - Registrar Nuevo Item - Registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity.Id;
        }

        /// <summary>
        /// Actualizar Registro - Item
        /// </summary>
        /// <returns></returns>
        public async Task UpdateAsync()
        {
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Eliminar Registro - Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task DeleteAsync(int id)
        {
            var entity = await FindByIdAsync(id);
            if (entity != null)
            {
                entity.Estado = "I";
                await UpdateAsync();
            }
            else
            {
                throw new InvalidOperationException($"No se encontro el registro con el id {id}");
            }
        }

        /// <summary>
        /// Listar
        /// </summary>
        /// <typeparam name="TInfo"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public async Task<ICollection<TInfo>> ListAsync<TInfo>(Expression<Func<TEntity, TInfo>> selector)
        {
            return await Context.Set<TEntity>()
                  .AsQueryable()
                  .Select(selector)
                  .ToListAsync();
        }

        /// <summary>
        /// Listar
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
        public async Task<(ICollection<TInfo> Collection, int Total)> ListAsync<TInfo, TKey>
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
    }
}
