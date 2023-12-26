using INSN.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.ViewModels
{
    public class LoginViewModel
    {
        public ICollection<SistemaDtoResponse>? Sistemas { get; set; }

        [Required]
        public string Usuario { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
    }
}
