using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response.Sistemas;
using System.ComponentModel.DataAnnotations;
using INSN.Web.Models.Response.SegApp;

namespace INSN.Web.ViewModels.SegApp.Mantenimiento
{
    /// <summary>
    /// UsuarioViewModel
    /// </summary>
    public class UsuarioViewModel : BaseModel
    {
        /// <summary>
        /// Lista de Usuarios
        /// </summary>       
        public ICollection<UsuarioDtoResponse>? Usuarios { get; set; }

        /// <summary>
        /// Lista de Tipos de doc identidad
        /// </summary>       
        public ICollection<TipoDocumentoIdentidadDtoResponse>? TiposDocIdentidad { get; set; }

        /// <summary>
        /// Lista de Sistemas
        /// </summary>       
        public ICollection<SistemaDtoResponse>? Sistemas { get; set; }

        /// <summary>
        /// Lista de Roles
        /// </summary>       
        public ICollection<RolDtoResponse>? Roles { get; set; }

        /// <summary>
        /// Lista de Roles
        /// </summary>       
        public ICollection<UsuarioRolDtoResponse>? UsuarioRoles { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Display(Name = "Id")]
        public string? Id { get; set; } = default!;

        /// <summary>
        /// Texto Buscar
        /// </summary>
        [Display(Name = "TextoBuscar")]
        public string? TextoBuscar { get; set; } = default!;

        /// <summary>
        /// Nombres
        /// </summary>
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; } = default!;

        /// <summary>
        /// Apellido Paterno
        /// </summary>
        [Display(Name = "ApellidoPaterno")]
        public string? ApellidoPaterno { get; set; } = default!;

        /// <summary>
        /// Apellido Materno
        /// </summary>
        [Display(Name = "ApellidoMaterno")]
        public string? ApellidoMaterno { get; set; }

        /// <summary>
        /// Servicio
        /// </summary>
        [Display(Name = "Servicio")]
        public string? Servicio { get; set; } = default!;

        /// <summary>
        /// Telefono1
        /// </summary>
        [Display(Name = "Telefono1")]
        public string? Telefono1 { get; set; } = default!;

        /// <summary>
        /// Telefono2
        /// </summary>
        [Display(Name = "Telefono2")]
        public string? Telefono2 { get; set; }

        /// <summary>
        /// Tipo Documento Identidad Id
        /// </summary>
        [Display(Name = "TipoDocumentoIdentidadId")]
        public int TipoDocumentoIdentidadId { get; set; }

        /// <summary>
        /// Documento Identidad
        /// </summary>
        [Display(Name = "DocumentoIdentidad")]
        public string? DocumentoIdentidad { get; set; } = default!;

        /// <summary>
        /// Usuario
        /// </summary>
        [Display(Name = "Usuario")]
        public string? Usuario { get; set; } = default!;

        /// <summary>
        /// Correo
        /// </summary>
        [Display(Name = "Correo")]
        public string? Correo { get; set; } = default!;

        /// <summary>
        /// Clave
        /// </summary>
        [Display(Name = "Clave")]
        public string? Clave { get; set; } = default!;

        /// <summary>
        /// Confirma Clave
        /// </summary>
        [Display(Name = "ConfirmaClave")]
        public string? ConfirmaClave { get; set; } = default!;

        /// <summary>
        /// Sistema Seleccionado
        /// </summary>
        [Display(Name = "SistemaSeleccionado")]
        public int SistemaSeleccionado { get; set; } = default!;

        /// <summary>
        /// Rol Seleccionado
        /// </summary>
        [Display(Name = "RolSeleccionado")]
        public string? RolSeleccionado { get; set; } = default!;

        /// <summary>
        /// Codigo Usuario Rol Id
        /// </summary>
        [Display(Name = "CodigoUsuarioRolId")]
        public int? CodigoUsuarioRolId { get; set; } = default!;

        /// <summary>
        /// Estados
        /// </summary>
        public ICollection<BaseModel> Estados { get; } = new List<BaseModel>()
        {
            new() { Codigo = "A", Nombre = "Activo" },
            new() { Codigo = "I", Nombre = "Inactivo" },
        };
    }
}