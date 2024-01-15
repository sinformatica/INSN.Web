using System.ComponentModel.DataAnnotations;
using INSN.Web.Models.Response.Home;

namespace INSN.Web.ViewModels.Home;

public class LibroReclamacionViewModel : BaseModel
{
    public string? NroDocumento { get; set; }

    public string? Nombres { get; set; }

    public string? Domicilio { get; set; }

    public string? Telefono { get; set; }

    public string? Celular { get; set; }

    public string? Email { get; set; }

    public string? Reclamo { get; set; }
}