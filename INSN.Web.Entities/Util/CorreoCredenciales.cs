using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.Util
{
    /// <summary>
    /// Correo Credenciales
    /// </summary>
    public class CorreoCredenciales : AuditoriaBase
    {
        /// <summary>
        /// Codigo Correo Credenciales Id
        /// </summary>
        public int CodigoCorreoCredencialesId { get; set; } = default!;

        /// <summary>
        /// Usuario
        /// </summary>
        public string? Usuario { get; set; } = default!;

        /// <summary>
        /// Clave
        /// </summary>
        public string? Clave { get; set; } = default!;

        /// <summary>
        /// Host
        /// </summary>
        public string? Host { get; set; } = default!;

        /// <summary>
        /// Puerto
        /// </summary>
        public string? Puerto { get; set; } = default!;
    }
}