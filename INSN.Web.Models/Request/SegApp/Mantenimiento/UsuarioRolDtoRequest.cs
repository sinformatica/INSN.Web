using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Request.SegApp.Mantenimiento
{
    public class UsuarioRolDtoRequest : BaseRequest
    {
        public string UserId { get; set; } = default!;

        public string? RolId { get; set; } = default!;

        public int CodigoSistemaId { get; set; } = default!;

        //[Required]
        //public List<RolSistemaDtoRequest> ListaRoles { get; set; } = default!;
    }

    //public class RolSistemaDtoRequest
    //{
    //    public string rol { get; set; } = default!;
    //    public int CodigoSistemaId { get; set; } = default!;
    //}
}
