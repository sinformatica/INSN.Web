using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models
{
    public class LoginDtoRequest
    {
        [Required(ErrorMessage = "El campo usuario es obligatorio.")]
        [Display(Name = "Usuariox")]
        public string Usuario { get; set; } = default!;

        [Required(ErrorMessage = "El campo contraseña es obligatorio.")]
        [Display(Name = "Password")]
        public string Password { get; set; } = default!;
    }

    public class LoginSistemaDtoRequest
    {
        [Required]
        public string Usuario { get; set; } = default!;

        [Required]
        public int CodigoSistemaId { get; set; } = default!;
    }
}
