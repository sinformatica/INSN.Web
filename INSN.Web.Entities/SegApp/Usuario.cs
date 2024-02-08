using INSN.Web.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace INSN.Web.Entities.SegApp
{
    /// <summary>
    /// Entidad Logica Usuario
    /// </summary>
    public class Usuario : AuditoriaBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; } = default!;

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
        /// servicio
        /// </summary>
        public string? Servicio { get; set; }

        /// <summary>
        /// Telefono2
        /// </summary>
        public string? Telefono2 { get; set; }

        /// <summary>
        /// TipoDocumentoIdentidad - Tipo Documento Identidad Id
        /// </summary>
        [ForeignKey("TipoDocumentoIdentidadId")]
        public TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; } = default!;

        /// <summary>
        /// TipoDocumentoIdentidadId
        /// </summary>
        public int TipoDocumentoIdentidadId { get; set; } = default!;

        /// <summary>
        /// Documento Identidad
        /// </summary>
        public string? DocumentoIdentidad { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// NormalizedUserName
        /// </summary>
        public string? NormalizedUserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// NormalizedEmail
        /// </summary>
        public string? NormalizedEmail { get; set; }

        /// <summary>
        /// PasswordHash
        /// </summary>
        public string? PasswordHash { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string? PhoneNumber { get; set; }
    }
}