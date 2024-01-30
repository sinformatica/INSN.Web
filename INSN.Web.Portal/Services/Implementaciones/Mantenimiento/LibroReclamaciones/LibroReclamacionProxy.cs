using INSN.Web.Models.Request.Mantenimiento.LibroReclamaciones;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Mantenimiento.LibroReclamacion;
using INSN.Web.Portal.Services.Interfaces.Mantenimiento.LibroReclamaciones;

namespace INSN.Web.Portal.Services.Implementaciones.Mantenimiento.LibroReclamaciones;

/// <summary>
/// Clase Proxy Libro Reclamacion
/// </summary>
public class LibroReclamacionProxy : CrudRestHelperBase<LibroReclamacionDtoRequest, LibroReclamacionDtoResponse>, ILibroReclamacionProxy
{
    public LibroReclamacionProxy(HttpClient httpClient)
        : base("api/Mantenimiento/LibroReclamacion/LibroReclamacion", httpClient)
    {
    }

    /// <summary>
    /// Proxy: Libro Reclamacion Insertar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task LibroReclamacionInsertar(LibroReclamacionDtoRequest request)
    {
        var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}/LibroReclamacionInsertar", request);
        if (response.IsSuccessStatusCode)
        {
            var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
            if (resultado!.Success == false)
                throw new InvalidOperationException(resultado.ErrorMessage);
        }
        else
        {
            throw new InvalidOperationException(response.ReasonPhrase);
        }
    }
}