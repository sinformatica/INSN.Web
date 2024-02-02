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
        public int CodigoSistemaId { get; set; }

        /// <summary>
        /// descripcion
        /// </summary>
        public string descripcion { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// icono
        /// </summary>
        public string icono { get; set; }

        /// <summary>
        /// Target
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// UsarToken
        /// </summary>
        public int UsarToken { get; set; }
    }
}