using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.Home.DocumentoInstitucional
{
    /// <summary>
    /// Entidad Logica de Tipo Documento
    /// </summary>
    public class TipoDocumento : AuditoriaBase
    {
        /// <summary>
        /// Codigo Tipo Documento Id
        /// </summary>
        public int CodigoTipoDocumentoId { get; set; }

        /// <summary>
        /// Area del Tipo de Norma
        /// </summary>
        public string Area { get; set; } = default!;

        /// <summary>
        /// Descripcion del Tipo de Norma
        /// </summary>
        public string? Descripcion { get; set; } = default!;
    }
}