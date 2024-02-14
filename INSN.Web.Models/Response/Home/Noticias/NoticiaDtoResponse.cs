namespace INSN.Web.Models.Response.Home.Noticias
{
    /// <summary>
    /// Noticia Dto Response
    /// </summary>
    public class NoticiaDtoResponse : BaseResponse
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

        /// <summary>
        /// Imagen Bytes
        /// </summary>
        public byte[] ImagenBytes { get; set; } = default!;

        /// <summary>
        /// Extension
        /// </summary>
        public string? Extension { get; set; }

        /// <summary>
        /// Detalle Lista
        /// </summary>
        public ICollection<NoticiaDetalleDtoResponse>? DetalleLista { get; set; }
    }
}