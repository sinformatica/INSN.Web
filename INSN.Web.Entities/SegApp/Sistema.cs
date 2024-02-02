using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.SegApp
{
    /// <summary>
    /// Sistema
    /// </summary>
    public class Sistema : AuditoriaBase
    {
        /// <summary>
        /// Codigo Sistema Id
        /// </summary>
        public int CodigoSistemaId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
    }
}