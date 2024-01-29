using INSN.Web.Models.Response;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Mantenimiento.OportunidadLaboral;
using INSN.Web.Entities.Mantenimiento.LibroReclamacion;

namespace INSN.Web.Services.Interfaces.Mantenimiento.OportunidadLaboral
{
    /// <summary>
    /// Interface Servicio Libro Reclamacion
    /// </summary>
    public interface ILibroReclamacionService
    {
        /// <summary>
        /// Documento Libro Reclamacion Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> LibroReclamacionInsertar(LibroReclamacionDtoRequest request);
    }
}