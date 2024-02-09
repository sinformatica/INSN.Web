using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home.Comunicados;

namespace INSN.Web.Services.Interfaces.Home.Comunicados
{
    /// <summary>
    /// Interface Comunicado
    /// </summary>
    public interface IComunicadoService
    {
        #region[Comunicado]
        /// <summary>
        /// Comunicado Listar
        /// </summary>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<ComunicadoDtoResponse>>> ComunicadoListar();
        #endregion

        #region[Comunicado detalle]
        /// <summary>
        /// Comunicado Detalle Listar
        /// </summary>
        /// <param name="CodigoComunicadoId"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<ComunicadoDetalleDtoResponse>>> ComunicadoDetalleListar(int CodigoComunicadoId);
        #endregion
    }
}