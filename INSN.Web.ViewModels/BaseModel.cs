using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace INSN.Web.ViewModels;

public class BaseModel
{
    public string? Codigo { get; set; }
    public string Nombre { get; set; } = default!;

    [Display(Name = "Estado")]
    public string? EstadoSeleccionado { get; set; }

    public int Rows { get; set; }
    public int Page { get; set; }
}