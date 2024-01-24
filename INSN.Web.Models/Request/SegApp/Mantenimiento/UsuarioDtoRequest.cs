using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Request.SegApp.Mantenimiento
{
    public class UsuarioDtoRequest : BaseRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; }

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
        public string? ApellidoMaterno { get; set; }

        /// <summary>
        /// Servicio
        /// </summary>
        public string? Servicio { get; set; } = default!;

        /// <summary>
        /// Telefono2
        /// </summary>
        public string? Telefono2 { get; set; }

        /// <summary>
        /// TipoDocumentoIdentidadId
        /// </summary>
        public int TipoDocumentoIdentidadId { get; set; } = default!;

        /// <summary>
        /// DocumentoIdentidad
        /// </summary>
        public string? DocumentoIdentidad { get; set; }

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
        /// Password
        /// </summary>
        public string? Password { get; set; } = default!;

        /// <summary>
        /// ConfirmarPassword
        /// </summary>
        [Compare(nameof(Password))]
        public string? ConfirmarPassword { get; set; } = default!;

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string? PhoneNumber { get; set; } = default!;
    }
}
