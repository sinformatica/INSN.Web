namespace INSN.Web.Models.Request.Home
{
    /// <summary>
    /// Clase EL Documento Convocatoria
    /// </summary>
    public class ConvocatoriaDtoRequest : AuditoriaRequest
    {
        /// <summary>
        /// Codigo  Convocatoria Id
        /// </summary>
        public int CodigoConvocatoriaId { get; set; }

        /// <summary>
        /// Descripcion del Documento
        /// </summary>
        public string? Descripcion { get; set; } = default!;

        /// <summary>
        /// Codigo Tipo Convocatoria Id
        /// </summary>
        public int CodigoTipoConvocatoriaId { get; set; }
    }
}
