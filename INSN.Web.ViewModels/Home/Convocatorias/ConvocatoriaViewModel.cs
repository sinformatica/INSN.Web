using INSN.Web.Models.Response.Home.Convocatorias;

namespace INSN.Web.ViewModels.Home.Convocatorias;

/// <summary>
/// Convocatoria View Model
/// </summary>
public class ConvocatoriaViewModel : BaseModel
{
    /// <summary>
    /// Lista de Convocatorias Tipo
    /// </summary>
    public ICollection<ConvocatoriaTipoDtoResponse>? ConvocatoriaTipoLista { get; set; }

    /// <summary>
    /// Lista de Convocatorias
    /// </summary>
    public ICollection<ConvocatoriaDtoResponse>? ConvocatoriaLista { get; set; }
}