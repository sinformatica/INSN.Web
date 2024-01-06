using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Response.SegApp.Mantenimiento
{
    public class UsuarioRolDtoResponse : BaseResponse
    {
        /// <summary>
        /// Nombre Rol
        /// </summary>
        public string NombreRol { get; set; } = default!;

        /// <summary>
        /// Role Id
        /// </summary>
        public string RoleId { get; set; } = default!;

        /// <summary>
        /// Nombre Sistema
        /// </summary>
        public string NombreSistema { get; set; } = default!;

        /// <summary>
        /// Codigo Sistema Id
        /// </summary>
        public int CodigoSistemaId { get; set; } = default!;
    }
}
