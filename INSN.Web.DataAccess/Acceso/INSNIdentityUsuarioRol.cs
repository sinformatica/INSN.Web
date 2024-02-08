using INSN.Web.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace INSN.Web.DataAccess.Acceso
{
    /// <summary>
    /// INSNIdentityUsuarioRol
    /// </summary>
    public class INSNIdentityUsuarioRol : AuditoriaBase
    {
        /// <summary>
        /// CodigoUsuarioRolId
        /// </summary>
        public int CodigoUsuarioRolId { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; } = default!;

        /// <summary>
        /// RoleId
        /// </summary>
        public string RoleId { get; set; } = default!;

        /// <summary>
        /// Sistema
        /// </summary>
        [ForeignKey("CodigoSistemaId")]
        public INSNIdentitySistema Sistema { get; set; } = default!;

        /// <summary>
        /// CodigoSistemaId
        /// </summary>
        public int CodigoSistemaId { get; set; }
    }
}