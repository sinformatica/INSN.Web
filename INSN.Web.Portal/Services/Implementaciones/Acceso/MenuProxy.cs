using INSN.Web.Models.Response.Sistemas;
using INSN.Web.Models.Response;
using INSN.Web.Models;
using INSN.Web.Models.Response.Sistema;
using INSN.Web.Models.Request.Sistema;
using INSN.Web.ViewModels;
using INSN.Web.Common;
using System.IdentityModel.Tokens.Jwt;
using INSN.Web.Portal.Services.Interfaces.Acceso;

namespace INSN.Web.Portal.Services.Implementaciones.Acceso
{
    /// <summary>
    /// Clase Proxy Menu
    /// </summary>
    public class MenuProxy : RestBase, IMenuProxy
    {
        /// <summary>
        /// Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        public MenuProxy(HttpClient httpClient)
            : base("api/Acceso/Menu", httpClient)
        {

        }

        /// <summary>
        /// Proxy: Seccion Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<SeccionDtoResponse>> SeccionListar(SeccionDtoRequest request)
        {
            try
            {
                var queryString = $"?CodigoSistemaId={request.CodigoSistemaId}";
                queryString += $"&RolId={request.RolId}";
                var response = await HttpClient.GetAsync($"{BaseUrl}/SeccionListar{queryString}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<SeccionDtoResponse>>>();

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

        /// <summary>
        /// Proxy: Modulo Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<ModuloDtoResponse>> ModuloListar(ModuloDtoRequest request)
        {
            try
            {
                var queryString = $"?CodigoSeccionId={request.CodigoSeccionId}";
                queryString += $"&RolId={request.RolId}";
                var response = await HttpClient.GetAsync($"{BaseUrl}/ModuloListar{queryString}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<ModuloDtoResponse>>>();

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
