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
        /// Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = default!;
    }
}
