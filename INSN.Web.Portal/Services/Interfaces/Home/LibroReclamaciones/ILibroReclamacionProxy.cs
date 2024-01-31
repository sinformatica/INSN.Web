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
    Task LibroReclamacionInsertar(LibroReclamacionDtoRequest request);
}