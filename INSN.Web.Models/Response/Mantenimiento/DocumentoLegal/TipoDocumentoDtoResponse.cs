namespace INSN.Web.Models.Response.Mantenimiento.DocumentoLegal
{
    public class TipoDocumentoDtoResponse : BaseResponse
    {
        /// <summary>
        /// Identificador de Tipo Documento
        /// </summary>
        public int CodigoTipoDocumentoId { get; set; }

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