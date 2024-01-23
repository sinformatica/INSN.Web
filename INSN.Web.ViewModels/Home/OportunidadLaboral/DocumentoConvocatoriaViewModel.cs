using System.ComponentModel.DataAnnotations;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response.Home.OportunidadLaboral;

namespace INSN.Web.ViewModels.Home;

public class DocumentoConvocatoriaViewModel : BaseModel
{
    public ICollection<DocumentoConvocatoriaDtoResponse>? DocumentoConvocatorias { get; set; }

    public string? PDF { get; set; }

    public List<GrupoDocumentoConvocatoria> DocumentoConvocatoriasAgrupados { get; set; }

}
public class GrupoDocumentoConvocatoria
{
    public int CodigoConvocatoriaId { get; set; }
    public string? DescripcionConvocatoria { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinal { get; set; }
    public int CodigoTipoConvocatoriaId { get; set; }
    public string? DescripcionTipoConvocatoria { get; set; }

    public List<DocumentoConvocatoriaDtoResponse> Detalles { get; set; }
}