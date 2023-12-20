using INSN.Web.Models.Request;

namespace INSN.Web.Models.Request;

public class BusquedaDocumentoLegalRequest : RequestBase
{
    public string? Documento { get; set; }
    public string? Descripcion { get; set; }
    public string? Area { get; set; }
    public int? TipoDocumentoId { get; set; }
    public string? Estado { get; set; }
    public int EstadoRegistro { get; set; }
}