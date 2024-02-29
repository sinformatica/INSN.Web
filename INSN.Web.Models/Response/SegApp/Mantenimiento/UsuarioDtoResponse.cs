namespace INSN.Web.Models.Response.SegApp.Mantenimiento
{
    /// <summary>
    /// Clase Usuario Dto Response
    /// </summary>
    public class UsuarioDtoResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; } = default!;

        /// <summary>
        /// Nombres
        /// </summary>
        public string Nombres { get; set; } = default!;

        /// <summary>
        /// Apellido Paterno
        /// </summary>
        public string ApellidoPaterno { get; set; } = default!;

        /// <summary>
        /// Apellido Materno
        /// </summary>
        public string? ApellidoMaterno { get; set; }

        /// <summary>
        /// Servicio
        /// </summary>
        public string Servicio { get; set; } = default!;

        /// <summary>
        /// Telefono2
        /// </summary>
        public string? Telefono2 { get; set; }

        /// <summary>
        /// Abreviatura Tipo Documento Identidad
        /// </summary>
        public string AbreviaturaTipoDocumentoIdentidad { get; set; } = default!;

        /// <summary>
        /// TipoDocumentoIdentidadId
        /// </summary>
        public int TipoDocumentoIdentidadId { get; set; } = default!;

        /// <summary>
        /// Documento Identidad
        /// </summary>
        public string DocumentoIdentidad { get; set; } = default!;

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; } = default!;

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; } = default!;

        /// <summary>
        /// Clave
        /// </summary>
        public string Clave { get; set; } = default!;

        /// <summary>
        /// Success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Estado A:Activo I:Inactivo
        /// </summary>
        public string Estado { get; set; } = default!;

        /// <summary>
        /// Estado 0:Eliminado 1:Activo
        /// </summary>
        public int EstadoRegistro { get; set; }

        /// <summary>
        /// Fecha Creacion
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Usuario Creacion
        /// </summary>
        public string? UsuarioCreacion { get; set; }

        /// <summary>
        /// Terminal Creacion
        /// </summary>
        public string? TerminalCreacion { get; set; }

        /// <summary>
        /// Fecha Modificacion
        /// </summary>
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// Usuario Modificacion
        /// </summary>
        public string? UsuarioModificacion { get; set; }

        /// <summary>
        /// Terminal Modificacion
        /// </summary>
        public string? TerminalModificacion { get; set; }
    }
}