namespace INSN.Web.Models.Request.Home
{
    /// <summary>
    /// Clase EL Documento Legal
    /// </summary>
    public class DocumentoLegalDtoRequest : AuditoriaRequest
    {        
        /// <summary>
        /// Nombre
        /// </summary>
        public int? CodigoDocumentoLegalId { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string? Documento { get; set; } = default!;

        /// <summary>
        /// Descripcion del Documento
        /// </summary>
        public string? Descripcion { get; set; } = default!;

        /// <summary>
        /// Area del Documento
        /// </summary>
        public string? Area { get; set; } = default!;      

        /// <summary>
        /// Fecha que fue publicado el documento
        /// </summary>
        public DateTime? FechaPublicacion { get; set; } = default!;

        /// <summary>
        /// ID de Tipo Documento
        /// </summary>
        public int? CodigoTipoDocumentoId { get; set; }
    }
}
