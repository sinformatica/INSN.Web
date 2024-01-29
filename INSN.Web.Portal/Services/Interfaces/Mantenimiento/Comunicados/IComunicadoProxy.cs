using INSN.Web.Models.Request.Mantenimiento.Comunicados;
using INSN.Web.Models.Response.Mantenimiento.Comunicados;

namespace INSN.Web.Portal.Services.Interfaces.Mantenimiento.Comunicados
{
    /// <summary>
    /// Interface Comunicado
    /// </summary>
    public interface IComunicadoProxy : ICrudRestHelper<ComunicadoDtoRequest, ComunicadoDtoResponse>
    {
        #region[Comunicado]
        /// <summary>
        /// IProxy: Comunicado Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<ComunicadoDtoResponse>> ComunicadoListar(ComunicadoDtoRequest request);
        #endregion

        #region[Comunicado Detalle]
        /// <summary>
        /// IProxy: Comunicado Detalle Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<ComunicadoDetalleDtoResponse>> ComunicadoDetalleListar(int CodigoComunicadoId);
        #endregion
    }
}