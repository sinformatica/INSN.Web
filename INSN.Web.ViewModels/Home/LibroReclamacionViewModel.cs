using System.ComponentModel.DataAnnotations;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response.SegApp;

namespace INSN.Web.ViewModels.Home;

public class LibroReclamacionViewModel : BaseModel
{
    /// <summary>
    /// Tipo Persona
    /// </summary>
    public string? TipoPersonaSeleccionada { get; set; }
    
    public ICollection<BaseModel> TipoPersona { get; } = new List<BaseModel>()
        {
            new() { Codigo = "Natural", Nombre = "Persona Natural" },
            new() { Codigo = "Juridica", Nombre = "Persona Jurídica" },
        };

    /// <summary>
    /// Tipo Documento Identidad
    /// </summary>
    public string ? TipoDocumentoIdentidad { get; set; }

    /// <summary>
    /// Nombres
    /// </summary>
    public string? Nombres { get; set; }

    /// <summary>
    /// Apellido Paterno
    /// </summary>
    public string? ApellidoPaterno { get; set; }

    /// <summary>
    /// Apellido Materno
    /// </summary>
    public string? ApellidoMaterno { get; set; }

    /// <summary>
    /// Dirección
    /// </summary>
    public string? Dirección { get; set; }

    /// <summary>
    /// Celular Teléfono
    /// </summary>
    public string? CelularTeléfono { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Reclamo
    /// </summary>
    public string? Reclamo { get; set; }

    /// <summary>
    /// Documento Identidad
    /// </summary>
    public string? DocumentoIdentidad { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Display(Name = "Tipo Documento")]
    public int? TipoDocumentoIdentidadSeleccionada { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [Display(Name = "Tipo Documento")]
    public int? TipoDocumentoIdentidadPacienteSeleccionada { get; set; }

    /// <summary>
    /// Nombres
    /// </summary>
    public string? NombresPaciente { get; set; }

    /// <summary>
    /// Apellido Paterno
    /// </summary>
    public string? ApellidoPaternoPaciente { get; set; }

    /// <summary>
    /// Apellido Materno
    /// </summary>
    public string? ApellidoMaternoPaciente { get; set; }

    /// <summary>
    /// Documento Identidad
    /// </summary>
    public string? DocumentoIdentidadPaciente { get; set; }

    /// <summary>
    /// Tipo Persona
    /// </summary>
    public string? TipoParentescoSeleccionada { get; set; }

    public ICollection<BaseModel> TipoParentesco { get; } = new List<BaseModel>()
        {
            new() { Codigo = "Madre", Nombre = "Madre" },
            new() { Codigo = "Padre", Nombre = "Padre" },
            new() { Codigo = "Apoderado", Nombre = "Apoderado" },
        };

    /// <summary>
    /// RUC
    /// </summary>
    public string? RUC { get; set; }

    /// <summary>
    /// Razón Social
    /// </summary>
    public string? RazónSocial { get; set; }

    /// <summary>
    /// Tipos de Documentos de Identidad
    /// </summary>
    public ICollection<TipoDocumentoIdentidadDtoResponse> TiposDocumentosIdentidad { get; set; } = default!;


}