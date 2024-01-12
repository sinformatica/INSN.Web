using INSN.Web.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace INSN.Web.Entities.DocumentoLegal
{
    /// <summary>
    /// Entidad Logica : Documento Legal
    /// </summary>
    public class DocumentoLegal : AuditoriaBase
    {
        /// <summary>
        /// Codigo Documento Legal Id
        /// </summary>
        public int? CodigoDocumentoLegalId { get; set; }

        /// <summary>
        /// Nombres
        /// </summary>
        public string Documento { get; set; } = default!;

        /// <summary>
        /// Descripcion del Documento
        /// </summary>
        public string? Descripcion { get; set; } = default!;

        /// <summary>
        /// PDF
        /// </summary>
        public string? PDF { get; set; } = default!;

        /// <summary>
        /// Fecha que fue publicado el documento
        /// </summary>
        public DateTime? FechaPublicacion { get; set; } = default!;

        /// <summary>
        /// Descripcion del Tipo de Norma
        /// </summary>
        [ForeignKey("TipoDocumentoId")]
        public TipoDocumento TipoDocumento { get; set; } = default!;

        /// <summary>
        /// ID de Tipo Documento
        /// </summary>
        public int? CodigoTipoDocumentoId { get; set; }

        /// <summary>
        /// Area del Documento
        /// </summary>
        public string? Area { get; set; } = default!;        
    }
}