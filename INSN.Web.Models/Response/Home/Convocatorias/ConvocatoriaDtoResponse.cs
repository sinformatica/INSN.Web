namespace INSN.Web.Models.Response.Home.Convocatorias
{
    /// <summary>
    /// Clase ConvocatoriaDtoResponse
    /// </summary>
    public class ConvocatoriaDtoResponse : BaseResponse
    {
        /// <summary>
        /// Codigo Convocatoria Id
        /// </summary>
        public int CodigoConvocatoriaId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string? Descripcion { get; set; } = default!;

        /// <summary>
        /// Fecha Inicio
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha Inicio
        /// </summary>
        public DateTime FechaFinal { get; set; }

        /// <summary>
        /// Codigo Convocatoria Tipo Id
        /// </summary>
        public int CodigoConvocatoriaTipoId { get; set; }

        /// <summary>
        /// Descripcion Convocatoria Tipo
        /// </summary>
        public string? DescripcionConvocatoriaTipo { get; set; } = default!;

        /// <summary>
        /// Detalle Lista
        /// </summary>
        public ICollection<ConvocatoriaDetalleDtoResponse>? DetalleLista { get; set; }
    }
}