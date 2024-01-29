using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Mantenimiento.DocumentoLegal;

namespace INSN.Web.Portal.Services.Interfaces.Mantenimiento.DocumentoInstitucional;

public interface ITipoDocumentoProxy : ICrudRestHelper<TipoDocumentoDtoRequest, TipoDocumentoDtoResponse>
{
    /// <summary>
    /// IProxy: Tipo Documento Listar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ICollection<TipoDocumentoDtoResponse>> TipoDocumentoListar(TipoDocumentoDtoRequest request);
}