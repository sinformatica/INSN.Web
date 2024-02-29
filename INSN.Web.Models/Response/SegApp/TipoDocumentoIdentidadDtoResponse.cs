namespace INSN.Web.Models.Response.SegApp
{
    /// <summary>
    /// Clase Tipo Documento Identidad DtoResponse
    /// </summary>
    public class TipoDocumentoIdentidadDtoResponse : BaseResponse
    {
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; } = default!;

        /// <summary>
        /// Abreviatura
        /// </summary>
        public string Abreviatura { get; set; } = default!;
    }
}