namespace INSN.Web.Models.Request.Home.Anuncios
{
    /// <summary>
    /// Anuncio Dto Request
    /// </summary>
    public class AnuncioDtoRequest : AuditoriaRequest
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
        /// Ruta Imagen
        /// </summary>
        public string? RutaImagen { get; set; } = default!;

        /// <summary>
        /// Extension
        /// </summary>
        public string? Extension { get; set; } = default!;
    }
}