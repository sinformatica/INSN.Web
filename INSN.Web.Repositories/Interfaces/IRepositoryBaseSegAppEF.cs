using INSN.Web.Entities.Base;
using System.Linq.Expressions;

namespace INSN.Web.Repositories.Interfaces
{
    /// <summary>
    /// Interface de Repositorio Base
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryBaseSegAppEF<TEntity> where TEntity : AuditoriaBase
    {
        /// <summary>
        /// IRepository: Listar objetos basados en el EntityBase
        /// </summary>
        Task<ICollection<TEntity>> Listar(Expression<Func<TEntity, bool>>? predicate = null);

        /// <summary>
        /// IRepository: Lista de objetos del EntityBase con un selector
        /// </summary>
        Task<ICollection<TInfo>> Listar<TInfo>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TInfo>> selector,
            string? relationships = null);

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
        Task<(ICollection<TInfo> Collection, int Total)> Listar<TInfo, TKey>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TInfo>> selector,
            Expression<Func<TEntity, TKey>> orderBy,
            string? relationships,
            int page, int rows);

        /// <summary>
        /// IRepository: Lista de objetos del EntityBase con un selector y sin predicado
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
        /// IRepository: Buscar un registro por ID
        /// </summary>
        Task<TEntity?> BuscarId(int id);

        /// <summary>
        /// IRepository: Buscar un registro por ID
        /// </summary>
        Task<TEntity?> BuscarStringId(string? id);

        /// <summary>
        /// IRepository: Actualizar cambios en la BD
        /// </summary>
        Task Actualizar();

        /// <summary>
        /// IRepository: Actualizar ciertos campos
        /// </summary>
        Task<int> ActualizarCampos(Expression<Func<TEntity, bool>> predicate, Action<TEntity> updateAction);

        /// <summary>
        /// IRepository: Eliminar un registro de la BD
        /// </summary>
        Task Eliminar(int id);

        /// <summary>
        /// IRepository: Eliminar un registro de la BD por Id string
        /// </summary>
        Task EliminarString(string id);
    }
}