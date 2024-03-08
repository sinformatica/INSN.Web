using INSN.Web.Models.Request.Home.Anuncios;
using INSN.Web.Models.Request.Home.Comunicados;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home.Anuncios;
using INSN.Web.Models.Response.Home.Comunicados;
using INSN.Web.Portal.Services.Interfaces.Home.Anuncios;
using INSN.Web.Portal.Services.Interfaces.Home.Comunicados;

namespace INSN.Web.Portal.Services.Implementaciones.Home.Anuncios
{
    /// <summary>
    /// Clase Proxy Anuncio
    /// </summary>
    public class AnuncioProxy : CrudRestHelperBase<AnuncioDtoRequest, AnuncioDtoResponse>, IAnuncioProxy
    {
        /// <summary>
        /// Comunicado Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="httpContextAccessor"></param>
        public AnuncioProxy(HttpClient httpClient, IHttpContextAccessor? httpContextAccessor)
        : base("api/Mantenimiento/Anuncio", httpClient)
        {
        }

        /// <summary>
        /// Proxy: Anuncio Listar
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ICollection<AnuncioDtoResponse>> AnuncioListar(AnuncioDtoRequest request)
        {
            try
            {
                var queryString = $"?NombreReferencial={request.NombreReferencial}&FechaExpiracion={request.FechaExpiracion.ToString("yyyy-MM-dd")}&Estado={request.Estado}&EstadoRegistro={request.EstadoRegistro}";
                var response = await HttpClient.GetAsync($"{BaseUrl}/AnuncioListar{queryString}");
                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<AnuncioDtoResponse>>>();

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
}