namespace INSN.Web.Models.Response.Home.Anuncios
{
    /// <summary>
    /// Anuncio Dto Response
    /// </summary>
    public class AnuncioDtoResponse : BaseResponse
    {
        /// <summary>
        /// Codigo Anuncio Id
        /// </summary>
        public int CodigoAnuncioId { get; set; }

        /// <summary>
        /// Nombre referencial
        /// </summary>
        public string? NombreReferencial { get; set; } = default!;

        /// <summary>
        /// Fecha Expiracion
        /// </summary>
        public DateTime FechaExpiracion { get; set; } = default!;

        /// <summary>
        /// Ruta Imagen
        /// </summary>
        public string? RutaImagen { get; set; } = default!;

        /// <summary>
        /// Extension
        /// </summary>
        public string? Extension { get; set; }

        /// <summary>
        /// Imagen Bytes
        /// </summary>
        public byte[] ImagenBytes { get; set; } = default!;
    }
}