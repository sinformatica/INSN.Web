using INSN.Web.Entities.SegApp;

namespace INSN.Web.Repositories.Interfaces.Acceso
{
    /// <summary>
    /// Interface Repository Menu
    /// </summary>
    public interface IMenuRepository : IRepositoryBaseSegApp<Seccion>
    {
        /// <summary>
        /// Seccion Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<Seccion>> SeccionListar(Seccion request);

        /// <summary>
        /// Modulo Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<Modulo>> ModuloListar(Modulo request);
    }
}