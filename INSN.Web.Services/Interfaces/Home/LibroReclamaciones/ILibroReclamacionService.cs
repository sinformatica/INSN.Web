using INSN.Web.Models.Request.Home.LibroReclamaciones;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home.LibroReclamaciones;

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

        /// <summary>
        /// Libro Reclamacion Actualizar
        /// </summary>
        /// <param name="CodigoLibroReclamacionId"></param>
        /// <param name="RutaImagen"></param>
        /// <returns></returns>
        Task<BaseResponse> LibroReclamacionRutaImagenActualizar(int CodigoLibroReclamacionId, string RutaImagen);
    }
}