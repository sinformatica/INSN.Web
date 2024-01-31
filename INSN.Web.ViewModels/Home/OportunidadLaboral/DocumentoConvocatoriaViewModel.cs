using INSN.Web.Models.Response.Home.OportunidadLaboral;

namespace INSN.Web.ViewModels.Home.OportunidadLaboral;

public class DocumentoConvocatoriaViewModel : BaseModel
{
    public ICollection<ConvocatoriaDtoResponse>? DocumentoConvocatorias { get; set; }

    public string? PDF { get; set; }

    public List<GrupoDocumentoConvocatoria> DocumentoConvocatoriasAgrupados { get; set; }

}
public class GrupoDocumentoConvocatoria
{
    /// <summary>
    /// Codigo Convocatoria Id
    /// </summary>
    public int CodigoConvocatoriaId { get; set; }

    /// <summary>
    /// Descripcion Convocatoria
    /// </summary>
    public string? DescripcionConvocatoria { get; set; }

    /// <summary>
    /// Fecha Inicio
    /// </summary>
    public DateTime FechaInicio { get; set; }

    /// <summary>
    /// Fecha Final
    /// </summary>
    public DateTime FechaFinal { get; set; }

    /// <summary>
    /// Codigo Tipo Convocatoria Id
    /// </summary>
    public int CodigoTipoConvocatoriaId { get; set; }

    /// <summary>
    /// Descripcion Tipo Convocatoria
    /// </summary>
    public string? DescripcionTipoConvocatoria { get; set; }

    /// <summary>
    /// Estado : C= Concluida, E: En Proceso
    /// </summary>
    public string? Estado { get; set; }

    /// <summary>
    /// Detalles
    /// </summary>
    public List<ConvocatoriaDtoResponse> Detalles { get; set; }
}