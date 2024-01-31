using INSN.Web.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace INSN.Web.Entities.Home.Comunicados
{
    public class ComunicadoDetalle : AuditoriaBase
    {
        /// <summary>
        /// Codigo Comunicado Id
        /// </summary>
        public int? CodigoComunicadoDetalleId { get; set; }

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
        public string? RutaImagen { get; set; }
    }
}