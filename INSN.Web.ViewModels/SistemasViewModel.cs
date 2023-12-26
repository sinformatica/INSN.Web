using INSN.Web.Models;
using INSN.Web.Models.Response.Sistemas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.ViewModels
{
    public class SistemasViewModel
    {
        public ICollection<SistemaDtoResponse>? ListaSistema { get; set; }

        public string Usuario { get; set; } = default!;

    }
}
