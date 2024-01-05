using INSN.Web.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Entities
{
    public class Rol : AuditoriaBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>      
        public string? Name { get; set; } = default!;

        /// <summary>
        /// NormalizedName
        /// </summary>
        public string? NormalizedName { get; set; } 

        /// <summary>
        /// ConcurrencyStamp
        /// </summary>
        public string? ConcurrencyStamp { get; set; } 
    }
}
