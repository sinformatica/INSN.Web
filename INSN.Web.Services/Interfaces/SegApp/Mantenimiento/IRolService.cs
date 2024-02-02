using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;

namespace INSN.Web.Services.Interfaces.SegApp.Mantenimiento
{
    /// <summary>
    /// IRolService
    /// </summary>
    public interface IRolService
    {
        /// <summary>
        /// Rol Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<RolDtoResponse>>> RolListar(RolDtoRequest request);

        /// <summary>
        /// IService: Rol Buscar Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<RolDtoResponse>> RolBuscarId(string Id);

        /// <summary>
        /// IService: Rol Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> RolInsertar(RolDtoRequest request);

        /// <summary>
        /// IService: Rol Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> RolActualizar(RolDtoRequest request);

        /// <summary>
        /// IService: Rol Eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<BaseResponse> RolEliminar(string Id);

        /// <summary>
        /// Rol Por Sistema Listar
        /// </summary>
        /// <param name="CodigoSistemaId"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<RolDtoResponse>>> RolPorSistemaListar(int CodigoSistemaId);
    }
}