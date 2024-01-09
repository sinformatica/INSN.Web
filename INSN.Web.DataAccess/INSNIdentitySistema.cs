using INSN.Web.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.DataAccess
{
    public class INSNIdentitySistema : AuditoriaBase
    {
        public int CodigoSistemaId { get; set; }
        public string descripcion { get; set; }
        public string url { get; set; }
        public string icono { get; set; }
        public string Target { get; set; }
        public int UsarToken { get; set; }
    }
}
