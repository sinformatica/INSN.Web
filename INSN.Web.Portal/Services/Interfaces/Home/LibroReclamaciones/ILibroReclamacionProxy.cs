using INSN.Web.Models.Request.Home.LibroReclamaciones;
using INSN.Web.Models.Response.Home.LibroReclamaciones;

namespace INSN.Web.Portal.Services.Interfaces.Home.LibroReclamaciones;

/// <summary>
/// Interface Libro Reclamacion
/// </summary>
public interface ILibroReclamacionProxy : ICrudRestHelper<LibroReclamacionDtoRequest, LibroReclamacionDtoResponse>
{
    /// <summary>
    /// IProxy: Libro Reclamacion Insertar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<int> LibroReclamacionInsertar(LibroReclamacionDtoRequest request);

    /// <summary>
    /// IProxy: Libro Reclamacion Ruta Imagen Actualizar
    /// </summary>
    /// <param name="CodigoLibroReclamacionId"></param>
    /// <param name="RutaImagen"></param>
    /// <returns></returns>
    Task LibroReclamacionRutaImagenActualizar(int CodigoLibroReclamacionId, string RutaImagen);
}