using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home.OportunidadLaboral;

namespace INSN.Web.Portal.Services.Interfaces.Home.OportunidadLaboral;

/// <summary>
/// Interface Documento Lega Producto
/// </summary>
public interface IDocumentoConvocatoriaProxy : ICrudRestHelper<ConvocatoriaDtoRequest, ConvocatoriaDtoResponse>
{
    /// <summary>
    /// IProxy: Documento Convocatoria Listar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ICollection<ConvocatoriaDtoResponse>> DocumentoConvocatoriaListar(ConvocatoriaDtoRequest request);
}