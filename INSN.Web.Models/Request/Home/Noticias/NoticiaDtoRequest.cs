namespace INSN.Web.Models.Request.Home.Noticias
{
    /// <summary>
    /// Noticia Dto Request
    /// </summary>
    public class NoticiaDtoRequest : AuditoriaRequest
    {
        /// <summary>
        /// Codigo Noticia Id
        /// </summary>
        public int CodigoNoticiaId { get; set; }

        /// <summary>
        /// Titulo
        /// </summary>
        public string? Titulo { get; set; } = default!;

        /// <summary>
        /// Codigo Fecha
        /// </summary>
        public string? CodigoFecha { get; set; } = default!;

        /// <summary>
        /// Fecha
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Fecha Expiracion
        /// </summary>
        public DateTime FechaExpiracion { get; set; }

        /// <summary>
        /// Parrafo1
        /// </summary>
        public string? Parrafo1 { get; set; } = default!;

        /// <summary>
        /// Parrafo2
        /// </summary>
        public string? Parrafo2 { get; set; } = default!;

        /// <summary>
        /// Ruta Imagen Portada
        /// </summary>
        public string? RutaImagenPortada { get; set; }
    }
}