using INSN.Web.Models.Request.Home.DocumentoLegal;
using INSN.Web.Models.Response.Home.DocumentoLegal;

namespace INSN.Web.Portal.Services.Interfaces.Home.DocumentoInstitucional;

/// <summary>
/// Interface Documento Lega Producto
/// </summary>
public interface IDocumentoLegalProxy : ICrudRestHelper<DocumentoLegalDtoRequest, DocumentoLegalDtoResponse>
{
    /// <summary>
    /// IProxy: Documento Legal Listar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ICollection<DocumentoLegalDtoResponse>> DocumentoLegalListar(DocumentoLegalDtoRequest request);
}