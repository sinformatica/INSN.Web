using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.SegApp
{
    /// <summary>
    /// Entidad Logica Usuario Info
    /// </summary>
    public class UsuarioInfo : AuditoriaBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; } = default!;

        /// <summary>
        /// Nombres
        /// </summary>
        public string? Nombres { get; set; } = default!;

        /// <summary>
        /// Apellido Paterno
        /// </summary>
        public string? ApellidoPaterno { get; set; } = default!;

        /// <summary>
        /// Apellido Materno
        /// </summary>
        public string? ApellidoMaterno { get; set; } = default!;

        /// <summary>
        /// servicio
        /// </summary>
        public string? Servicio { get; set; } = default!;

        /// <summary>
        /// Telefono2
        /// </summary>
        public string? Telefono2 { get; set; } = default!;

        /// <summary>
        /// Abreviatura Tipo Documento Identidad
        /// </summary>
        public string? AbreviaturaTipoDocumentoIdentidad { get; set; } = default!;

        /// <summary>
        /// TipoDocumentoIdentidadId
        /// </summary>
        public int TipoDocumentoIdentidadId { get; set; }

        /// <summary>
        /// Documento Identidad
        /// </summary>
        public string? DocumentoIdentidad { get; set; } = default!;

        /// <summary>
        /// UserName
        /// </summary>
        public string? UserName { get; set; } = default!;

        /// <summary>
        /// NormalizedUserName
        /// </summary>
        public string? NormalizedUserName { get; set; } = default!;

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; } = default!;

        /// <summary>
        /// NormalizedEmail
        /// </summary>
        public string? NormalizedEmail { get; set; } = default!;

        /// <summary>
        /// PasswordHash
        /// </summary>
        public string? PasswordHash { get; set; } = default!;

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string? PhoneNumber { get; set; } = default!;
    }
}