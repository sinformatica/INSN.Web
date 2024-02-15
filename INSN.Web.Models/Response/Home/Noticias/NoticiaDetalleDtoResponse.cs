namespace INSN.Web.Models.Response.Home.Noticias
{
    /// <summary>
    /// Noticia Detalle Dto Response
    /// </summary>
    public class NoticiaDetalleDtoResponse : BaseResponse
    {
        /// <summary>
        /// Codigo Noticia Detalle Id
        /// </summary>
        public int CodigoNoticiaDetalleId { get; set; }

        /// <summary>
        /// Codigo Noticia Id
        /// </summary>
        public int CodigoNoticiaId { get; set; }

        /// <summary>
        /// Ruta Imagen
        /// </summary>
        public string? RutaImagen { get; set; }

        /// <summary>
        /// Imagen Bytes
        /// </summary>
        public byte[]? ImagenBytes { get; set; }

        /// <summary>
        /// Extension
        /// </summary>
        public string? Extension { get; set; }
    }
}