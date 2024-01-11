using INSN.Web.Models;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Sistemas;
using INSN.Web.Portal.Services.Interfaces.SegApp;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Services.Implementaciones.SegApp
{
    /// <summary>
    /// Clase Proxy Sistema
    /// </summary>
    public class SistemaProxy : CrudRestHelperBase<SistemaDtoRequest, SistemaDtoResponse>, ISistemaProxy
    {
        /// <summary>
        /// Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        public SistemaProxy(HttpClient httpClient)
        : base("api/SegApp/Sistema", httpClient)
        {
        }

        /// <summary>
        /// Proxy: Sistema Listar
        /// </summary>
        /// <param name="request"></param>
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
