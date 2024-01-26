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
    public class ComunicadoDetalle : AuditoriaBase
    {
        /// <summary>
        /// Codigo Comunicado Id
        /// </summary>
        public int? CodigoComunicadoDetId { get; set; }

        /// <summary>
        /// Comunicado - CodigoComunicadoId
        /// </summary>
        [ForeignKey("CodigoComunicadoId")]
        public Comunicado Comunicado { get; set; } = default!;

        /// <summary>
        /// UserId
        /// </summary>
        public int CodigoComunicadoId { get; set; }

        /// <summary>
        /// Ruta Imagen
        /// </summary>
        public string? NombreImagen { get; set; }
    }
}
