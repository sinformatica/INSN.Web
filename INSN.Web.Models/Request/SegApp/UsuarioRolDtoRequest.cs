using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Request.SegApp
{
    public class UsuarioRolDtoRequest
    {
        [Required]
        public string UsuarioId { get; set; } = default!;

        [Required]
        public List<string> roles { get; set; } = default!;

    }
}
