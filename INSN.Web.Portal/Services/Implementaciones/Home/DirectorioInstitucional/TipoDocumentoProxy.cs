using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home;
using INSN.Web.Portal.Services.Interfaces.Home.DirectorioInstitucional;

namespace INSN.Web.Portal.Services.Implementaciones.Home.DirectorioInstitucional;

public class TipoDocumentoProxy : CrudRestHelperBase<TipoDocumentoDtoRequest, TipoDocumentoDtoResponse>, ITipoDocumentoProxy
{
    public TipoDocumentoProxy(HttpClient httpClient)
        : base("api/TipoDocumento", httpClient)
    {
    }
}