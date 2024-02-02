using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;

namespace INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento
{
    /// <summary>
    /// IUsuarioProxy
    /// </summary>
    public interface IUsuarioProxy : ICrudRestHelper<UsuarioDtoRequest, UsuarioDtoResponse>
    {
        /// <summary>
        /// IProxy: Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<UsuarioDtoResponse>> UsuarioListar(UsuarioDtoRequest request);

        /// <summary>
        /// IProxy: Usuario Validar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> UsuarioValidar(UsuarioDtoRequest request);

        /// <summary>
        /// IProxy: Usuario Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UsuarioInsertar(UsuarioDtoRequest request);

        /// <summary>
        /// IProxy: Usuario Buscar Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UsuarioDtoResponse> UsuarioBuscarId(string id);

        /// <summary>
        /// IProxy: Usuario Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UsuarioActualizar(UsuarioDtoRequest request);

        /// <summary>
        /// IProxy: Usuario Eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UsuarioEliminar(string id);

        /// <summary>
        /// IProxy: Usuario Actualizar Clave
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UsuarioActualizarClave(UsuarioDtoRequest request);
    }
}