namespace INSN.Web.Models.Response.SegApp.Mantenimiento
{
    /// <summary>
    /// Clase Rol Dto Response
    /// </summary>
    public class RolDtoResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; } = default!;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = default!;

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