namespace INSN.Web.Models.Response.Home.DocumentoLegal
{
    /// <summary>
    /// Clase DocumentoLegalDtoResponse
    /// </summary>
    public class DocumentoLegalDtoResponse : BaseResponse
    {
        /// <summary>
        /// Nombre
        /// </summary>
        public string Documento { get; set; } = default!;

        /// <summary>
        /// Descripcion del Documento
        /// </summary>
        public string Descripcion { get; set; } = default!;

        /// <summary>
        /// Ruta Archivo
        /// </summary>
        public string RutaArchivo { get; set; } = default!;

        /// <summary>
        /// Fecha que fue publicado el documento
        /// </summary>
        public DateTime FechaPublicacion { get; set; } = default!;

        /// <summary>
        /// Descripcion del Tipo de Norma
        /// </summary>
        public string TipoDocumento { get; set; } = default!;

        /// <summary>
        /// ID de Tipo Documento
        /// </summary>
        public int TipoDocumentoId { get; set; }
    }
}