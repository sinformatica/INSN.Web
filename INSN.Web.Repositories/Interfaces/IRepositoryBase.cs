﻿using INSN.Web.Entities.Base;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Interfaces
{
    /// <summary>
    /// Interface de Repositorio Base
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryBase<TEntity> where TEntity : AuditoriaBase
    {  
        /// <summary>
        /// Listar objetos basados en el EntityBase
        /// </summary>
        Task<ICollection<TEntity>> Listar(Expression<Func<TEntity, bool>>? predicate = null);

        /// <summary>
        /// Lista de objetos del EntityBase con un selector
        /// </summary>
        Task<ICollection<TInfo>> Listar<TInfo>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TInfo>> selector,
            string? relationships = null);

        Task<(ICollection<TInfo> Collection, int Total)> Listar<TInfo, TKey>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TInfo>> selector,
            Expression<Func<TEntity, TKey>> orderBy,
            string? relationships,
            int page, int rows);

        /// <summary>
        /// Lista de objetos del EntityBase con un selector y sin predicado
        /// </summary>
        Task<ICollection<TInfo>> Listar<TInfo>(
            Expression<Func<TEntity, TInfo>> selector);

        /// <summary>
        /// IRepository: Insertar un nuevo registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> Insertar(TEntity entity);

        /// <summary>
        /// Buscar un registro por ID
        /// </summary>
        Task<TEntity?> BuscarId(int id);

        /// <summary>
        /// Actualizar cambios en la BD
        /// </summary>
        Task Actualizar();

        /// <summary>
        /// Eliminar un registro de la BD
        /// </summary>
        Task Eliminar(int id);
    }
}