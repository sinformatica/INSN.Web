using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.DataAccess
{
    public class INSNIdentityUsuarioRol 
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        [ForeignKey("CodigoSistemaId")]
        public INSNIdentitySistema Sistema { get; set; }

        public int CodigoSistemaId { get; set; }
    }
}
