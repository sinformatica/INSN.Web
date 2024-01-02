using INSN.Web.Models.Response.Sistema;
using INSN.Web.Models.Response.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.ViewModels
{
    public class SeccionViewModel
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public ICollection<SeccionDtoResponse>? SeccionLista { get; set; }
    }
}
