using INSN.Web.Entities.Base;

namespace INSN.Web.DataAccess.Acceso
{
    /// <summary>
    /// INSNIdentitySistema
    /// </summary>
    public class INSNIdentitySistema : AuditoriaBase
    {
        /// <summary>
        /// CodigoSistemaId
        /// </summary>
        public int CodigoSistemaId { get; set; } = default!;

        /// <summary>
        /// descripcion
        /// </summary>
        public string descripcion { get; set; } = default!;

        /// <summary>
        /// url
        /// </summary>
        public string url { get; set; } = default!;

        /// <summary>
        /// icono
        /// </summary>
        public string icono { get; set; } = default!;

        /// <summary>
        /// Target
        /// </summary>
        public string Target { get; set; } = default!;

        /// <summary>
        /// UsarToken
        /// </summary>
        public int UsarToken { get; set; } = default!;
    }
}