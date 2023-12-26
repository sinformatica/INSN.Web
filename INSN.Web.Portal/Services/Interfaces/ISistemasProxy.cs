using INSN.Web.Models;
using INSN.Web.Models.Response.Sistemas;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Services.Interfaces
{
    public interface ISistemasProxy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<SistemasDtoResponse>> ListarSistemasPorUsuario(LoginUsuarioDtoRequest request);
    }
}
