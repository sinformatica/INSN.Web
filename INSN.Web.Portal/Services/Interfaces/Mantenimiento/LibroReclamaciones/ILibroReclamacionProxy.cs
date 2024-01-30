using INSN.Web.Models.Request.Mantenimiento.LibroReclamaciones;
using INSN.Web.Models.Response.Mantenimiento.LibroReclamacion;

namespace INSN.Web.Portal.Services.Interfaces.Mantenimiento.LibroReclamaciones;

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