using INSN.Web.Models.Response;
using INSN.Web.Models;
using INSN.Web.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Response.Sistemas;

namespace INSN.Web.Portal.Services.Implementaciones
{
    /// <summary>
    /// Clase Proxy Usuario
    /// </summary>
    public class AccesoProxy : RestBase, IAccesoProxy
    {
        /// <summary>
        /// Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        public AccesoProxy(HttpClient httpClient)
            : base("api/Acceso", httpClient)
        {

        }

        /// <summary>
        /// Proxy: Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LoginDtoResponse> Login(LoginDtoRequest request)
        {
            return await SendAsync<LoginDtoRequest, LoginDtoResponse>(request, HttpMethod.Post, "Login");
        }

        /// <summary>
        /// Proxy: Sistemas Por Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<SistemaDtoResponse>> SistemasPorUsuarioListar(LoginUsuarioDtoRequest request)
        {
            try
            {
                var queryString = $"?Usuario={request.Usuario}";
                var response = await HttpClient.GetAsync($"{BaseUrl}/SistemasPorUsuarioListar{queryString}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<SistemaDtoResponse>>>();

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
