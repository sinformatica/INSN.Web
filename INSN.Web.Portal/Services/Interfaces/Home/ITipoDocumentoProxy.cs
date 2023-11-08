using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home;
using INSN.Web.Portal.Services.Interfaces;

namespace INSN.Web.Portal.Services.Interfaces;

public interface ITipoDocumentoProxy : ICrudRestHelper<TipoDocumentoDtoRequest, TipoDocumentoDtoResponse>
{
    
}