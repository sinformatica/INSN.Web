using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.Info.Mantenimiento
{
    /// <summary>
    /// Clase Entidad Logica Usuario Rol Info
    /// </summary>
    public class UsuarioRolInfo : AuditoriaBase
    {
        /// <summary>
        /// Codigo Usuario Rol Id
        /// </summary>
        public int? CodigoUsuarioRolId { get; set; }

        /// <summary>
        /// Nombre Rol
        /// </summary>
        public string ?NombreRol { get; set; } = default!;

        /// <summary>
        /// Role Id
        /// </summary>
        public string? RoleId { get; set; } = default!;

        /// <summary>
        /// Nombre Sistema
        /// </summary>
        public string? NombreSistema { get; set; } = default!;

        /// <summary>
        /// Codigo Sistema Id
        /// </summary>
        public int CodigoSistemaId { get; set; }
    }
}