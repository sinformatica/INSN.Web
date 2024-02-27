namespace INSN.Web.Models.Response.Home.Convocatorias
{
    /// <summary>
    /// Convocatoria Detalle Dto Response
    /// </summary>
    public class ConvocatoriaDetalleDtoResponse
    {
        /// <summary>
        /// Codigo Convocatoria Detalle Id
        /// </summary>
        public int CodigoConvocatoriaDetalleId { get; set; }

        /// <summary>
        /// Codigo Convocatoria Id
        /// </summary>
        public int CodigoConvocatoriaId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Ruta Archivo
        /// </summary>
        public string? RutaArchivo { get; set; }

        /// <summary>
        /// Archivo Bytes
        /// </summary>
        public byte[]? ArchivoBytes { get; set; }

        /// <summary>
        /// Extension
        /// </summary>
        public string? Extension { get; set; }

        /// <summary>
        /// Tipo Archivo
        /// </summary>
        public string? TipoArchivo { get; set; }

        /// <summary>
        /// Codigo Convocatoria Detalle Tipo Id
        /// </summary>
        public int CodigoConvocatoriaDetalleTipoId { get; set; }

        /// <summary>
        /// Descripcion Convocatoria Detalle Tipo
        /// </summary>
        public string? DescripcionConvocatoriaDetalleTipo { get; set; }
    }
}