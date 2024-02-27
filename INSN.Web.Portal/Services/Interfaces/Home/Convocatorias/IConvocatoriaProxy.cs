using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home.Convocatorias;

namespace INSN.Web.Portal.Services.Interfaces.Home.Convocatorias;

/// <summary>
/// IConvocatoria Proxy
/// </summary>
public interface IConvocatoriaProxy : ICrudRestHelper<ConvocatoriaDtoRequest, ConvocatoriaDtoResponse>
{
    #region[Convocatoria Tipo]
    /// <summary>
    /// IProxy: Convocatoria Tipo Listar
    /// </summary>
    /// <returns></returns>
    Task<ICollection<ConvocatoriaTipoDtoResponse>> ConvocatoriaTipoListar();
    #endregion

    #region[Convocatoria]
    /// <summary>
    /// IProxy: Convocatoria Listar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ICollection<ConvocatoriaDtoResponse>> ConvocatoriaListar(ConvocatoriaDtoRequest request);
    #endregion

    #region[Convocatoria Detalle]
    /// <summary>
    /// IProxy: Convocatoria Detalle Listar
    /// </summary>
    /// <param name="CodigoConvocatoriaId"></param>
    /// <returns></returns>
    Task<ICollection<ConvocatoriaDetalleDtoResponse>> ConvocatoriaDetalleListar(int CodigoConvocatoriaId);
    #endregion
}