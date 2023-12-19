using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Request.SegApp
{
    public class UsuarioDtoRequest
    {
        [Required]
        public string Usuario { get; set; } = default!;

        [Required]
        public string Nombres { get; set; } = default!;

        [Required]
        public string ApellidoPaterno { get; set; } = default!;

        public string? ApellidoMaterno { get; set; }

        [Required]
        public string Servicio { get; set; } = default!;

        [Required]
        public int TipoDocumentoIdentidadId { get; set; } = default!;

        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        public string Telefono { get; set; } = default!;

        public string? Telefono2 { get; set; }

        [Required]
        public string Password { get; set; } = default!;

        [Compare(nameof(Password))]
        public string ConfirmarPassword { get; set; } = default!;
    }
}
