using System.ComponentModel.DataAnnotations;

namespace INSN.Web.Models.Request.Acceso
{
    /// <summary>
    ///LoginDtoRequest
    /// </summary>
    public class LoginDtoRequest
    {
        /// <summary>
        /// Usuario
        /// </summary>
        [Required(ErrorMessage = "El campo usuario es obligatorio.")]
        [Display(Name = "Usuariox")]
        public string Usuario { get; set; } = default!;

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "El campo contraseña es obligatorio.")]
        [Display(Name = "Password")]
        public string Password { get; set; } = default!;
    }

    /// <summary>
    /// Login Usuario DtoR equest
    /// </summary>
    public class LoginUsuarioDtoRequest
    {
        /// <summary>
        /// Usuario
        /// </summary>
        [Required]
        public string Usuario { get; set; } = default!;
    }

    /// <summary>
    /// Login Sistema Dto Request
    /// </summary>
    public class LoginSistemaDtoRequest
    {
        /// <summary>
        /// Usuario
        /// </summary>
        [Required]
        public string Usuario { get; set; } = default!;

        /// <summary>
        /// Codigo Sistema Id
        /// </summary>
        [Required]
        public int CodigoSistemaId { get; set; } = default!;
    }
}