namespace INSN.Web.Models.Request.Home
{
    /// <summary>
    /// Clase EL Documento Legal
    /// </summary>
    public class DocumentoLegalDtoRequest
    {
        /// <summary>
        /// Nombre
        /// </summary>
        public string? Documento { get; set; } = default!;

        /// <summary>
        /// Descripcion del Documento
        /// </summary>
        public string? Descripcion { get; set; } = default!;       

        /// <summary>
        /// Fecha que fue publicado el documento
        /// </summary>
        public DateTime? FechaPublicacion { get; set; } = default!;

        /// <summary>
        /// ID de Tipo Documento
        /// </summary>
        public int? IdTipoDocumento { get; set; }
    }
}
