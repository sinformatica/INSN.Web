using INSN.Web.Models.Request.Home.DocumentoLegal;
using INSN.Web.Models.Response.Home.DocumentoLegal;

namespace INSN.Web.Portal.Services.Interfaces.Home.DocumentoInstitucional;

public interface ITipoDocumentoProxy : ICrudRestHelper<TipoDocumentoDtoRequest, TipoDocumentoDtoResponse>
{
    /// <summary>
    /// IProxy: Tipo Documento Listar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ICollection<TipoDocumentoDtoResponse>> TipoDocumentoListar(TipoDocumentoDtoRequest request);
}