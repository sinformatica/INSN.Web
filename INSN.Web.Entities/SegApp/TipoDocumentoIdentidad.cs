using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.SegApp
{
    /// <summary>
    /// TipoDocumentoIdentidad
    /// </summary>
    public class TipoDocumentoIdentidad : AuditoriaBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Abreviatura
        /// </summary>
        public string? Abreviatura { get; set; }
    }
}