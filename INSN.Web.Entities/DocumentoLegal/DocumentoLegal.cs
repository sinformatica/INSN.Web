using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.DocumentoLegal
{
    /// <summary>
    /// Entidad Logica : Documento Legal
    /// </summary>
    public class DocumentoLegal : EntityBase
    {  
        /// <summary>
        /// Nombre
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
        public string TipoDocumento { get; set; } = default!;

        /// <summary>
        /// ID de Tipo Documento
        /// </summary>
        public int IdTipoDocumento { get; set; }
    }
}