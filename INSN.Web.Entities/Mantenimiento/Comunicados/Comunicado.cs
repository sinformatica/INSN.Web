using INSN.Web.Entities.Base;
using INSN.Web.Entities.SegApp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Entities.Mantenimiento.Comunicado
{
    public class Comunicado : AuditoriaBase
    {
        /// <summary>
        /// Codigo Comunicado Id
        /// </summary>
        public int? CodigoComunicadoId { get; set; }

        /// <summary>
        /// Titulo
        /// </summary>
        public string? Titulo { get; set; }

        /// <summary>
        /// Fecha Publicacion
        /// </summary>
        public DateTime FechaPublicacion { get; set; }

        /// <summary>
        /// Fecha Expiracion
        /// </summary>
        public DateTime FechaExpiracion { get; set; }

        /// <summary>
        /// Nombre Modal
        /// </summary>
        public string? NombreModal { get; set; }

        /// <summary>
        /// Ruta Portada
        /// </summary>
        public string? RutaImagenPortada { get; set; }

        /// <summary>
        /// Ancho
        /// </summary>
        public int Ancho { get; set; }
    }
}
