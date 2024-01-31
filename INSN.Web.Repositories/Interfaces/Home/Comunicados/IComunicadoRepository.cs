using INSN.Web.Entities.Home.Comunicados;

namespace INSN.Web.Repositories.Interfaces.Home.Comunicados
{
    /// <summary>
    /// Interface de Metodos Comunicado
    /// </summary>
    public interface IComunicadoRepository : IRepositoryBase<Comunicado>
    {
        #region[Comunicado]
        /// <summary>
        /// IRepository: Comunicado Listar
        /// </summary>
        Task<ICollection<Comunicado>> ComunicadoListar(Comunicado request);
        #endregion

        #region[Comunicado detalle]
        /// <summary>
        /// IRepository: Comunicado Detalle Listar
        /// </summary>
        Task<ICollection<ComunicadoDetalle>> ComunicadoDetalleListar(int CodigoComunicadoId);
        #endregion
    }
}