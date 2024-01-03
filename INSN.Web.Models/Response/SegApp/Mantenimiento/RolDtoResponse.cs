using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Response.SegApp.Mantenimiento
{
    public class RolDtoResponse : BaseResponse
    {
        /// <summary>
        /// Codigo Farmacia Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Descripcion de Farmacia
        /// </summary>
        public string Name { get; set; } = default!;
    }
}
