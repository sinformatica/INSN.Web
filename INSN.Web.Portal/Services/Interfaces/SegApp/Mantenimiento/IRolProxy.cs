using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;

namespace INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento
{
    /// <summary>
    /// Interface Proxy Rol
    /// </summary>
    public interface IRolProxy : ICrudRestHelper<RolDtoRequest, RolDtoResponse>
    {
        /// <summary>
        /// IProxy: Rol Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<RolDtoResponse>> RolListar(RolDtoRequest request);

        /// <summary>
        /// IProxy: Rol Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task RolInsertar(RolDtoRequest request);

        /// <summary>
        /// IProxy: Rol Buscar Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RolDtoResponse> RolBuscarId(string id);

        /// <summary>
        /// IProxy: Rol Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task RolActualizar(RolDtoRequest request);

        /// <summary>
        /// IProxy: Rol Eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RolEliminar(string id);

        /// <summary>
        /// IProxy: Rol Por Sistema Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<RolDtoResponse>> RolPorSistemaListar(int CodigoSistemaId);
    }
}
