namespace INSN.Web.Models.Response.Home
{
    public class TipoDocumentoDtoResponse : AuditoriaResponse
    {
        /// <summary>
        /// Identificador de Tipo Documento
        /// </summary>
        public int CoditoTipoDocumentoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; } = default!;

        /// <summary>
        /// Area
        /// </summary>
        public string Area { get; set; } = default!;
    }
}
