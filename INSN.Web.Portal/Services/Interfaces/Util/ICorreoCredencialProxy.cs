using INSN.Web.Models.Response.Util;

namespace INSN.Web.Portal.Services.Interfaces.Util
{
    /// <summary>
    /// ICorreo Credencial Proxy
    /// </summary>
    public interface ICorreoCredencialProxy : ICrudRestHelper<CorreoCredencialDtoResponse, CorreoCredencialDtoResponse>
    {
        /// <summary>
        /// IProxy: Obtener Correo Credencial
        /// </summary>
        /// <returns></returns>
        Task<CorreoCredencialDtoResponse> ObtenerCorreoCredencial();
    }
}