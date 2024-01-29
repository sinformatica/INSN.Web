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
        /// <summary>
        /// Codigo Usuario Rol Id
        /// </summary>
        public int? CodigoUsuarioRolId { get; set; } = default!;

        /// <summary>
        /// User Id
        /// </summary>
        public string UserId { get; set; } = default!;

        /// <summary>
        /// Rol Id
        /// </summary>
        public string? RolId { get; set; } = default!;

        /// <summary>
        /// Codigo Sistema Id
        /// </summary>
        public int CodigoSistemaId { get; set; } = default!;
    }
}
