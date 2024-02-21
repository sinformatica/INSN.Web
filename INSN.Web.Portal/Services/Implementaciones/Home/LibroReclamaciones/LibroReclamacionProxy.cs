using INSN.Web.Models.Request.Home.LibroReclamaciones;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home.LibroReclamaciones;
using INSN.Web.Portal.Services.Interfaces.Home.LibroReclamaciones;

namespace INSN.Web.Portal.Services.Implementaciones.Home.LibroReclamaciones;

/// <summary>
/// Clase Proxy Libro Reclamacion
/// </summary>
public class LibroReclamacionProxy : CrudRestHelperBase<LibroReclamacionDtoRequest, LibroReclamacionDtoResponse>, ILibroReclamacionProxy
{
    /// <summary>
    /// Libro Reclamacion Proxy
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="httpContextAccessor"></param>
    public LibroReclamacionProxy(HttpClient httpClient, IHttpContextAccessor? httpContextAccessor)
        : base("api/Home/LibroReclamacion", httpClient)
    {
    }

    /// <summary>
    /// Proxy: Libro Reclamacion Insertar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<int> LibroReclamacionInsertar(LibroReclamacionDtoRequest request)
    {
        var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}/LibroReclamacionInsertar", request);
        if (response.IsSuccessStatusCode)
        {
            var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
            if (resultado!.Success == false) throw new InvalidOperationException(resultado.ErrorMessage);

            return resultado.Id;
        }
        else
        {
            throw new InvalidOperationException(response.ReasonPhrase);
        }
    }

    /// <summary>
    /// Proxy: Libro Reclamacion Ruta Imagen Actualizar
    /// </summary>
    /// <param name="CodigoLibroReclamacionId"></param>
    /// <param name="RutaImagen"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task LibroReclamacionRutaImagenActualizar(int CodigoLibroReclamacionId, string RutaImagen)
    {
        var queryString = $"?CodigoLibroReclamacionId={CodigoLibroReclamacionId}&RutaImagen={RutaImagen}";
        var response = await HttpClient.PutAsync($"{BaseUrl}/LibroReclamacionRutaImagenActualizar{queryString}", null);
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