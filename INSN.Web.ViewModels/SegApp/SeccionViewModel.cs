using INSN.Web.Models.Response.Sistema;
using INSN.Web.Models.Response.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.ViewModels.SegApp
{
    public class SeccionViewModel
    {
        public ICollection<SeccionDtoResponse>? SeccionLista { get; set; }
    }
}
