using INSN.Web.Models.Response;
using INSN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Models.Response.Sistemas;

namespace INSN.Web.Services.Interfaces.SegApp
{
    public interface ISistemaService
    {
        /// <summary>
        /// Sistema Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<SistemaDtoResponse>>> SistemaListar();
    }
}
