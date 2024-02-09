using INSN.Web.Models.Request.Home.Comunicados;
using INSN.Web.Models.Response.Home.Comunicados;

namespace INSN.Web.Portal.Services.Interfaces.Home.Comunicados
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
        /// <returns></returns>
        Task<ICollection<ComunicadoDtoResponse>> ComunicadoListar();
        #endregion

        #region[Comunicado Detalle]
        /// <summary>
        /// IProxy: Comunicado Detalle Listar
        /// </summary>
        /// <param name="CodigoComunicadoId"></param>
        /// <returns></returns>
        Task<ICollection<ComunicadoDetalleDtoResponse>> ComunicadoDetalleListar(int CodigoComunicadoId);
        #endregion
    }
}