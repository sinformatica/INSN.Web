using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home;
using INSN.Web.Portal.Services.Interfaces.Home.DirectorioInstitucional;

namespace INSN.Web.Portal.Services.Implementaciones.Home.DirectorioInstitucional;

public class TipoDocumentoProxy : CrudRestHelperBase<TipoDocumentoDtoRequest, TipoDocumentoDtoResponse>, ITipoDocumentoProxy
{
    public TipoDocumentoProxy(HttpClient httpClient)
        : base("api/TipoDocumento", httpClient)
    {
    }

   /// <summary>
   /// 
   /// </summary>
   /// <param name="Area"></param>
   /// <param name="Estado"></param>
   /// <param name="EstadoRegistro"></param>
   /// <returns></returns>
   /// <exception cref="InvalidOperationException"></exception>
    public async Task<ICollection<TipoDocumentoDtoResponse>> TipoDocumentoListar(string Area, string Estado, int EstadoRegistro)
    {
        try
        {
            var queryString = $"?Area={Area}&Estado={Estado}&EstadoRegistro={EstadoRegistro}";
            var response = await HttpClient.GetAsync($"{BaseUrl}/TipoDocumentoListar{queryString}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<BaseResponseGeneric<ICollection<TipoDocumentoDtoResponse>>>();

            if (result!.Success == false)
            {
                throw new InvalidOperationException(result.ErrorMessage);
            }

            return result.Data!;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message);
        }
    }
}