using INSN.Web.Common;
using INSN.Web.Models;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Sistemas;
using INSN.Web.Portal.Services.Interfaces.SegApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace INSN.Web.Portal.Services.Implementaciones.SegApp
{
    /// <summary>
    /// SistemaProxy
    /// </summary>
    public class SistemaProxy : CrudRestHelperBase<SistemaDtoRequest, SistemaDtoResponse>, ISistemaProxy
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="httpContextAccessor"></param>
        public SistemaProxy(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        : base("api/SegApp/Sistema", httpClient)
        {
            _httpContextAccessor = httpContextAccessor;

            // Configurar la cabecera de autorización con el token
            string token = _httpContextAccessor.HttpContext.Session.GetString(Constantes.JwtToken);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        /// <summary>
        /// Proxy: Sistema Listar
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<SistemaDtoResponse>> SistemaListar()
        {
            try
            {
                var response = await HttpClient.GetAsync($"{BaseUrl}/SistemaListar");

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