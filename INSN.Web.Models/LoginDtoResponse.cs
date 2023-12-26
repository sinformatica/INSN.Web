using INSN.Web.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models
{
    public class LoginDtoResponse : BaseResponse
    {
        public string NombresCompletos { get; set; } = default!;
        public string Token { get; set; } = default!;
    } 
}
