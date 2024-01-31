namespace INSN.Web.Models.Request.Home.Comunicados
{
    /// <summary>
    /// Clase ComunicadoDetalleDtoRequest
    /// </summary>
    public class ComunicadoDetalleDtoRequest : AuditoriaRequest
    {
        /// <summary>
        /// Codigo Comunicado Detalle Id
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