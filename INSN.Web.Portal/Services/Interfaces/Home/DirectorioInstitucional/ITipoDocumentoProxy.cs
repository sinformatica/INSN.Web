using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home;

namespace INSN.Web.Portal.Services.Interfaces.Home.DirectorioInstitucional;

public interface ITipoDocumentoProxy : ICrudRestHelper<TipoDocumentoDtoRequest, TipoDocumentoDtoResponse>
{
    /// <summary>
    /// IProxy: Tipo Documento Listar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ICollection<TipoDocumentoDtoResponse>> TipoDocumentoListar(TipoDocumentoDtoRequest request);
}
