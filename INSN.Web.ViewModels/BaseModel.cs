using System.ComponentModel.DataAnnotations;

namespace INSN.Web.ViewModels;

/// <summary>
/// Clase Base Model
/// </summary>
public class BaseModel
{
    /// <summary>
    /// Codigo Base
    /// </summary>
    public string? Codigo { get; set; }

    /// <summary>
    /// Nombre Base
    /// </summary>
    public string Nombre { get; set; } = default!;

    /// <summary>
    /// Estado Seleccionado
    /// </summary>
    [Display(Name = "Estado")]
    public string? EstadoSeleccionado { get; set; }
}