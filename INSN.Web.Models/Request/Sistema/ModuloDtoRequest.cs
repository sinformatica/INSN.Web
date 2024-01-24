using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Request.Sistema
{
    public class ModuloDtoRequest
    {
        [Required]
        public int CodigoSeccionId { get; set; } = default!;

        [Required]
        public string RolId { get; set; } = default!;
    }
}
