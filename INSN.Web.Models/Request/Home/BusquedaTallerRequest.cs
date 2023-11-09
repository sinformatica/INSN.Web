using INSN.Web.Models.Request;

namespace INSN.Web.Models.Request;

public class BusquedaDocumentoLegalRequest : RequestBase
{
    public string? Filter { get; set; }
    public int? TipoDocumentoId { get; set; }
    public string? Estado { get; set; }
}