using INSN.Web.Entities.Home.LibroReclamacion;

namespace INSN.Web.Repositories.Interfaces.Home.LibroReclamaciones
{
    /// <summary>
    /// Interface de Metodos Libro Reclamacion
    /// </summary>
    public interface ILibroReclamacionRepository : IRepositoryBase<LibroReclamacion>
    {
        /// <summary>
        /// Libro Reclamacion Ruta Imagen Actualizar
        /// <param name="CodigoLibroReclamacionId"></param>
        /// <param name="RutaImagen"></param>
        /// </summary>
        Task LibroReclamacionRutaImagenActualizar(int CodigoLibroReclamacionId, string RutaImagen);
    }
}