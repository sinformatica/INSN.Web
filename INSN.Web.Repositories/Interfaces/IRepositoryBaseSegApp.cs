using INSN.Web.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Interfaces
{
    /// <summary>
    /// Interface de Repositorio Base SegApp
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryBaseSegApp<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// Listar objetos basados en el EntityBase
        /// </summary>
        Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? predicate = null);

        /// <summary>
        /// Lista de objetos del EntityBase con un selector
        /// </summary>
        Task<ICollection<TInfo>> ListAsync<TInfo>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TInfo>> selector,
            string? relationships = null);

        Task<(ICollection<TInfo> Collection, int Total)> ListAsync<TInfo, TKey>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TInfo>> selector,
            Expression<Func<TEntity, TKey>> orderBy,
            string? relationships,
            int page, int rows);

        /// <summary>
        /// Lista de objetos del EntityBase con un selector y sin predicado
        /// </summary>
        Task<ICollection<TInfo>> ListAsync<TInfo>(
            Expression<Func<TEntity, TInfo>> selector);

        /// <summary>
        /// Crear un registro
        /// </summary>
        Task<int> AddAsync(TEntity entity);

        /// <summary>
        /// Buscar un registro por ID
        /// </summary>
        Task<TEntity?> FindByIdAsync(int id);

        /// <summary>
        /// Actualizar cambios en la BD
        /// </summary>
        Task UpdateAsync();

        /// <summary>
        /// Eliminar un registro de la BD
        /// </summary>
        Task DeleteAsync(int id);
    }
}
