using INSN.Web.Entities.Util;

namespace INSN.Web.Repositories.Interfaces.Util
{
    /// <summary>
    /// ICorreo Credenciales Repository
    /// </summary>
    public interface ICorreoCredencialesRepository : IRepositoryBase<CorreoCredenciales>
    {
        /// <summary>
        /// Obtener Correo Credenciales
        /// </summary>
        Task<CorreoCredenciales> ObtenerCorreoCredenciales();
    }
}