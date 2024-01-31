namespace INSN.Web.Models.Response.Home.OportunidadLaboral
{
    /// <summary>
    /// Clase ConvocatoriaDtoResponse
    /// </summary>
    public class ConvocatoriaDtoResponse : BaseResponse
    {
        #region [Datos Convocatoria]
        /// <summary>
        /// Codigo Convocatoria Id
        /// </summary>
        public int CodigoConvocatoriaId { get; set; }

        /// <summary>
        /// Descripcion de la Convocatoria
        /// </summary>
        public string? DescripcionConvocatoria { get; set; } = default!;

        /// <summary>
        /// Fecha Inicio
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha Inicio
        /// </summary>
        public DateTime FechaFinal { get; set; }

        /// <summary>
        /// Codigo Tipo de Convocatoria Id
        /// </summary>
        public int CodigoTipoConvocatoriaId { get; set; }

        /// <summary>
        /// Descripcion Tipo de Convocatoria
        /// </summary>
        public string? DescripcionTipoConvocatoria { get; set; } = default!;
        #endregion

        #region[Cabecera de Sección]
        /// <summary>
        /// Codigo Tipo Documento Convocatoria Id
        /// </summary>
        public int CodigoTipoDocumentoConvocatoriaId { get; set; }

        /// <summary>
        /// Descripcion del Tipo de Convocatoria
        /// </summary>
        public string? DescripcionTipoDocumentoConvocatoria { get; set; } = default!;
        #endregion

        #region [Documento de Convocatoria]
        /// <summary>
        /// Codigo Documento Convocatoria Id
        /// </summary>
        public int? CodigoDocumentoConvocatoriaId { get; set; }

        /// <summary>
        /// Descripcion Documento Convocatoria
        /// </summary>
        public string? DescripcionDocumentoConvocatoria { get; set; } = default!;

        /// <summary>
        /// Ruta del documento PDF,Word
        /// </summary>
        public string? Ruta { get; set; } = default!;

        /// <summary>
        /// Tipo Archivo
        /// </summary>
        public string? TipoArchivo { get; set; } = default!;
        #endregion
    }
}