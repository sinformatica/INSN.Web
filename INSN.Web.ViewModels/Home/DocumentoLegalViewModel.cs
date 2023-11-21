using System.ComponentModel.DataAnnotations;
using INSN.Web.Models.Response.Home;

namespace INSN.Web.ViewModels.Home;

public class DocumentoLegalViewModel : BaseModel
{
    public string? Documento { get; set; }

    public string? Descripcion { get; set; }

    public ICollection<TipoDocumentoDtoResponse> TipoDocumentos { get; set; } = default!;

    [Display(Name = "Tipo")]
    public int? TipoDocumentoSeleccionada { get; set; }

    [Display(Name = "Estado")]
    public string? EstadoSeleccionado { get; set; }

    public ICollection<BaseModel> Estados { get; } = new List<BaseModel>()
    {
        new() { Codigo = "A", Nombre = "ACTIVO" },
        new() { Codigo = "B", Nombre = "INACTIVO" },
    };

    public int Rows { get; set; }
    public int Page { get; set; }
    public ICollection<DocumentoLegalDtoResponse>? DocumentoLegales { get; set; }

    public string? PDF { get; set; }

    public string? TituloPagina { get; set; }
}