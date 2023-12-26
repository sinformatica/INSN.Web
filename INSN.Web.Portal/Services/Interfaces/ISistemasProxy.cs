using INSN.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Services.Interfaces
{
    public interface ISistemasProxy
    {
        Task<ICollection<SistemaDtoResponse>> ListarSistemasPorUsuario(LoginUsuarioDtoRequest request);
    }
}
