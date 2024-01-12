using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home;

namespace INSN.Web.Portal.Services.Interfaces.Home.DirectorioInstitucional;

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