using INSN.Web.Models.Request.Home.LibroReclamaciones;
using INSN.Web.Models.Response;

namespace INSN.Web.Services.Interfaces.Home.LibroReclamaciones
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