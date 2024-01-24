using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Request
{
    public class BaseRequest : AuditoriaRequest
    {
        /// <summary>
        /// Página
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Fila
        /// </summary>
        public int Rows { get; set; }
    }
}
