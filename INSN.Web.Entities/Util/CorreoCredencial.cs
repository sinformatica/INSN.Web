using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.Util
{
    /// <summary>
    /// Correo Credencial
    /// </summary>
    public class CorreoCredencial : AuditoriaBase
    {
        /// <summary>
        /// Codigo Correo Credencial Id
        /// </summary>
        public int CodigoCorreoCredencialId { get; set; } = default!;

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
        public int Puerto { get; set; } = default!;
    }
}