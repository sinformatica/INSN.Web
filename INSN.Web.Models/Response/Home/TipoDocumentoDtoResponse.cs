namespace INSN.Web.Models.Response.Home
{
    public class TipoDocumentoDtoResponse
    {
        /// <summary>
        /// Identificador de Tipo Documento
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; } = default!;
    }
}
