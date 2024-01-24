using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Request
{
    public class AuditoriaRequest
    {
        /// <summary>
        /// Estado
        /// </summary>
        public string? Estado { get; set; } = default!;

        /// <summary>
        /// Estado Registro
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
