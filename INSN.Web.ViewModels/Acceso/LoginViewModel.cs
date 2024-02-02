using System.ComponentModel.DataAnnotations;

namespace INSN.Web.ViewModels.Acceso
{
    /// <summary>
    /// LoginViewModel
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Usuario
        /// </summary>
        [Required]
        public string Usuario { get; set; } = default!;

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; } = default!;
    }
}