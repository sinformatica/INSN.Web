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
        public List<RolSistemaDtoRequest> ListaRoles { get; set; } = default!;

    }

    public class RolSistemaDtoRequest
    {
        public string rol { get; set; } = default!;
        public int CodigoSistemaId { get; set; } = default!;

    }
}
