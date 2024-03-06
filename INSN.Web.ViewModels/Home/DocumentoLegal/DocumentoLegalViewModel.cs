using System.ComponentModel.DataAnnotations;
using INSN.Web.Models.Response.Home.DocumentoLegal;

namespace INSN.Web.ViewModels.Home.DocumentoLegal;

/// <summary>
/// Entidad Clase Documento Legal
/// </summary>
public class DocumentoLegalViewModel : BaseModel
{
    /// <summary>
    /// Documento
    /// </summary>
    public string? Documento { get; set; }

    /// <summary>
    /// Descripcion
    /// </summary>
    public string? Descripcion { get; set; }

    /// <summary>
    /// Codigo Tipo Documento Id
    /// </summary>
    public int? CodigoTipoDocumentoId { get; set; }

    /// <summary>
    /// Area
    /// </summary>
    public string? Area { get; set; }

    /// <summary>
    /// Tipo Documentos
    /// </summary>
    public ICollection<TipoDocumentoDtoResponse> TipoDocumentos { get; set; } = default!;

    /// <summary>
    /// Tipo Documento Seleccionada
    /// </summary>
    [Display(Name = "Tipo")]
    public int? TipoDocumentoSeleccionada { get; set; }

    /// <summary>
    /// Area Seleccionada
    /// </summary>
    public string? AreaSeleccionada { get; set; }

    /// <summary>
    /// Estados
    /// </summary>
    public ICollection<BaseModel> Estados { get; } = new List<BaseModel>()
    {
        new() { Codigo = "A", Nombre = "ACTIVO" },
        new() { Codigo = "B", Nombre = "INACTIVO" },
    };

    /// <summary>
    /// Documento Legales
    /// </summary>
    public ICollection<DocumentoLegalDtoResponse>? DocumentoLegales { get; set; }

    /// <summary>
    /// PDF
    /// </summary>
    public string? PDF { get; set; }

    /// <summary>
    /// Titulo Pagina
    /// </summary>
    public string? TituloPagina { get; set; }
}