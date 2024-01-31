using INSN.Web.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace INSN.Web.Entities.Home.OportunidadLaboral
{
    /// <summary>
    /// Entidad Logica : Documento Convocatoria
    /// </summary>
    public class DocumentoConvocatoria : AuditoriaBase
    {
        /// <summary>
        /// Codigo Documento Convocatoria Id
        /// </summary>
        public int? CodigoDocumentoConvocatoriaId { get; set; }

        /// <summary>
        /// Convocatoria
        /// </summary>
        [ForeignKey("CodigoConvocatoriaId")]
        public Convocatoria Convocatoria { get; set; } = default!;

        /// <summary>
        /// Descripcion de la Convocatoria
        /// </summary>
        public string? Descripcion { get; set; } = default!;

        /// <summary>
        /// Ruta del documento PDF,Word
        /// </summary>
        public string? Ruta { get; set; } = default!;

        /// <summary>
        /// Tipo Archivo
        /// </summary>
        public string? TipoArchivo { get; set; } = default!;

        /// <summary>
        /// Tipo Documento Convocatoria
        /// </summary>
        [ForeignKey("CodigoTipoDocumentoConvocatoriaId")]
        public TipoDocumentoConvocatoria TipoDocumentoConvocatoria { get; set; } = default!;
    }
}