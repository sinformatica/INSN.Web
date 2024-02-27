using INSN.Web.Models.Request.Home.UsuarioBibliotecas;
using INSN.Web.Models.Response.Home.UsuarioBibliotecas;

namespace INSN.Web.Portal.Services.Interfaces.Home.UsuarioBibliotecas;

/// <summary>
/// IUsuario Biblioteca Proxy
/// </summary>
public interface IUsuarioBibliotecaProxy : ICrudRestHelper<UsuarioBibliotecaDtoRequest, UsuarioBibliotecaDtoResponse>
{
    /// <summary>
    /// IProxy: Usuario Biblioteca Listar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    Task<ICollection<UsuarioBibliotecaDtoResponse>> UsuarioBibliotecaListar(UsuarioBibliotecaDtoRequest request);

    /// <summary>
    /// IProxy: Usuario Biblioteca Insertar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    Task<int> UsuarioBibliotecaInsertar(UsuarioBibliotecaDtoRequest request);
}