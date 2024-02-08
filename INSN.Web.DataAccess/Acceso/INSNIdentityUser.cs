using INSN.Web.Entities.SegApp;
using Microsoft.AspNetCore.Identity;

namespace INSN.Web.DataAccess.Acceso
{
    /// <summary>
    /// INSNIdentityUser
    /// </summary>
    public class INSNIdentityUser : IdentityUser
    {
        /// <summary>
        /// Nombres
        /// </summary>
        public string? Nombres { get; set; } = default!;

        /// <summary>
        /// ApellidoPaterno
        /// </summary>
        public string? ApellidoPaterno { get; set; } = default!;

        /// <summary>
        /// ApellidoMaterno
        /// </summary>
        public string? ApellidoMaterno { get; set; }

        /// <summary>
        /// servicio
        /// </summary>
        public string? servicio { get; set; } = default!;

        /// <summary>
        /// Telefono2
        /// </summary>
        public string? Telefono2 { get; set; }

        /// <summary>
        /// TipoDocumentoIdentidad
        /// </summary>
        public TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; } = default!;

        /// <summary>
        /// TipoDocumentoIdentidad - TipoDocumentoIdentidadId
        /// </summary>
        public int TipoDocumentoIdentidadId { get; set; }

        /// <summary>
        /// DocumentoIdentidad
        /// </summary>
        public string? DocumentoIdentidad { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string? Estado { get; set; } = default!;

        /// <summary>
        /// EstadoRegistro
        /// </summary>
        public int? EstadoRegistro { get; set; } = default!;
    }
}