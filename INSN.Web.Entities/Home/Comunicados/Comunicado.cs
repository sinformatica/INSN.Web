using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.Home.Comunicados
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
        /// Ruta Portada
        /// </summary>
        public string? RutaImagenPortada { get; set; }

        /// <summary>
        /// Ancho
        /// </summary>
        public int Ancho { get; set; }
    }
}