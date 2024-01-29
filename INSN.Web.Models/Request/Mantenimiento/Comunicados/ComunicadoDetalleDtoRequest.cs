using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Request.Mantenimiento.Comunicados
{
    public class ComunicadoDetalleDtoRequest : AuditoriaRequest
    {
        /// <summary>
        /// Codigo Comunicado Id
        /// </summary>
        public int? CodigoComunicadoDetId { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public int CodigoComunicadoId { get; set; }

        /// <summary>
        /// Ruta Imagen
        /// </summary>
        public string? RutaImagen { get; set; }
    }
}
