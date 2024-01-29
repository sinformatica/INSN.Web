namespace INSN.Web.Models.Response.Mantenimiento.Comunicados
{
    public class ComunicadoDtoResponse : BaseResponse
    {
        /// <summary>
        /// Codigo Comunicado Id
        /// </summary>
        public int CodigoComunicadoId { get; set; }

        /// <summary>
        /// Titulo
        /// </summary>
        public string? Titulo { get; set; } = default!;

        /// <summary>
        /// Fecha Publicacion
        /// </summary>
        public DateTime FechaPublicacion { get; set; } = default!;

        /// <summary>
        /// Fecha Expiracion
        /// </summary>
        public DateTime FechaExpiracion { get; set; } = default!;

        /// <summary>
        /// Nombre Modal
        /// </summary>
        public string? NombreModal { get; set; } = default!;

        /// <summary>
        /// Ruta Portada
        /// </summary>
        public string? RutaImagenPortada { get; set; } = default!;

        /// <summary>
        /// Ancho
        /// </summary>
        public int Ancho { get; set; }

        public ICollection<ComunicadoDetalleDtoResponse>? DetalleLista { get; set; }
    }
}
