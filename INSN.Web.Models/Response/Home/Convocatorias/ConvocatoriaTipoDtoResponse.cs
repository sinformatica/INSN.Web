namespace INSN.Web.Models.Response.Home.Convocatorias
{
    /// <summary>
    /// Convocatoria Tipo Dto Response
    /// </summary>
    public class ConvocatoriaTipoDtoResponse : BaseResponse
    {
        /// <summary>
        /// Codigo Convocatoria Tipo Id
        /// </summary>
        public int CodigoConvocatoriaTipoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string? Descripcion { get; set; }
    }
}