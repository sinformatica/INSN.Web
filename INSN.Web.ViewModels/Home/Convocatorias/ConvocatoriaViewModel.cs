using INSN.Web.Models.Response.Home.Convocatorias;

namespace INSN.Web.ViewModels.Home.Convocatorias;

/// <summary>
/// Clase Documento Convocatoria
/// </summary>
public class ConvocatoriaViewModel : BaseModel
{
    /// <summary>
    /// Lista de Convocatorias
    /// </summary>
    public ICollection<ConvocatoriaDtoResponse>? ConvocatoriaLista { get; set; }

    /// <summary>
    /// Documento Convocatorias
    /// </summary>
    //public ICollection<ConvocatoriaDtoResponse>? DocumentoConvocatorias { get; set; } = default!;

    ///// <summary>
    ///// PDF
    ///// </summary>
    //public string? PDF { get; set; } = default!;

    ///// <summary>
    ///// Documento Convocatorias Agrupados
    ///// </summary>
    //public List<GrupoDocumentoConvocatoria> DocumentoConvocatoriasAgrupados { get; set; } = default!;
}

/// <summary>
/// Clase Grupo Documento Convocatoria
/// </summary>
//public class GrupoDocumentoConvocatoria
//{
//    /// <summary>
//    /// Codigo Convocatoria Id
//    /// </summary>
//    public int CodigoConvocatoriaId { get; set; } = default!;

//    /// <summary>
//    /// Descripcion Convocatoria
//    /// </summary>
//    public string? DescripcionConvocatoria { get; set; } = default!;

//    /// <summary>
//    /// Fecha Inicio
//    /// </summary>
//    public DateTime FechaInicio { get; set; } = default!;

//    /// <summary>
//    /// Fecha Final
//    /// </summary>
//    public DateTime FechaFinal { get; set; } = default!;
 
//    /// <summary>
//    /// Codigo Tipo Convocatoria Id
//    /// </summary>
//    public int CodigoTipoConvocatoriaId { get; set; }

//    /// <summary>
//    /// Descripcion Tipo Convocatoria
//    /// </summary>
//    public string? DescripcionTipoConvocatoria { get; set; } = default!;

//    /// <summary>
//    /// Estado : C= Concluida, E: En Proceso
//    /// </summary>
//    public string? Estado { get; set; } = default!;

//    /// <summary>
//    /// Detalles
//    /// </summary>
//    public List<ConvocatoriaDtoResponse> Detalles { get; set; } = default!;
//}