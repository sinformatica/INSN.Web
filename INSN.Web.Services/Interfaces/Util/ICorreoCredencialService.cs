using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Util;

namespace INSN.Web.Services.Interfaces.Util
{
    /// <summary>
    /// ICorreo Credencial Service
    /// </summary>
    public interface ICorreoCredencialService
    {
        /// <summary>
        /// IService: Obtener Correo Credencial
        /// </summary>
        /// <returns></returns>
        Task<BaseResponseGeneric<CorreoCredencialDtoResponse>> ObtenerCorreoCredencial();
    }
}