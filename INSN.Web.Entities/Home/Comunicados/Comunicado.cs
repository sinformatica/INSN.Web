using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.Home.Comunicados
{
    /// <summary>
    /// Entrada Logica Comunicado
    /// </summary>
    public class Comunicado : AuditoriaBase
    {
        /// <summary>
        /// Codigo Comunicado Id
        /// </summary>
        public int? CodigoComunicadoId { get; set; }

        /// <summary>
        /// Titulo
        /// </summary>
        public string Titulo { get; set; } = default!;

        /// <summary>
        /// Fecha Publicacion
        /// </summary>
        public DateTime FechaPublicacion { get; set; }

        /// <summary>
        /// Fecha Expiracion
        /// </summary>
        public DateTime? FechaExpiracion { get; set; } = default!;

        /// <summary>
        /// Ruta Portada
        /// </summary>
        public string? RutaImagenPortada { get; set; } = default!;

        /// <summary>
        /// Ancho
        /// </summary>
        public int Ancho { get; set; }
    }
}