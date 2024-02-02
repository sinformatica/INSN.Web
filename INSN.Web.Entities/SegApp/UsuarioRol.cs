using INSN.Web.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace INSN.Web.Entities.SegApp
{
    /// <summary>
    /// UsuarioRol
    /// </summary>
    public class UsuarioRol : AuditoriaBase
    {
        /// <summary>
        /// Codigo Usuario Rol Id
        /// </summary>
        public int? CodigoUsuarioRolId { get; set; }

        /// <summary>
        /// Usuario - UserId
        /// </summary>
        [ForeignKey("UserId")]
        public Usuario Usuario { get; set; } = default!;

        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Rol - RoleId
        /// </summary>
        [ForeignKey("RoleId")]
        public Rol Rol { get; set; } = default!;

        /// <summary>
        /// Role Id
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Sistema - CodigoSistemaId
        /// </summary>
        [ForeignKey("CodigoSistemaId")]
        public Sistema Sistema { get; set; } = default!;

        /// <summary>
        /// CodigoSistemaId
        /// </summary>
        public int CodigoSistemaId { get; set; }
    }
}