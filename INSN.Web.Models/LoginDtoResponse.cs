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

    public class ListaSistemasDtoResponse : BaseResponse
    {
        public List<SistemaDtoResponse> ListaSistemas { get; set; } = default!;
    }

    public class SistemaDtoResponse 
    {
        public int CodigoSistemaId { get; set; } = default!;
        public string descripcion { get; set; } = default!;
        public string url { get; set; } = default!;
        public string icono { get; set; } = default!;
    }
}
