using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Request.SegApp.Mantenimiento
{
    /// <summary>
    /// Clase Entidad Lógica Resquest Rol
    /// </summary>
    public class RolDtoRequest : BaseRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string? Name { get; set; } = default!;
    }
}
