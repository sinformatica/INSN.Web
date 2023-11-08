using INSN.Web.Models.Request;

namespace INSN.Web.Models.Request;

public class BusquedaDocumentoLegalRequest : RequestBase
{
    public string? Filter { get; set; }
    public int? IdTipoDocumento { get; set; }
    public string? Estado { get; set; }
}