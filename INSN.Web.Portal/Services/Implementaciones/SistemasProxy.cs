using INSN.Web.Models;
using INSN.Web.Models.Response;
using INSN.Web.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Services.Implementaciones
{
    public class SistemasProxy : RestBase, ISistemasProxy
    {
        public SistemasProxy(HttpClient httpClient)
            : base("api/Sistemas", httpClient)
        {

        }

        public async Task<ICollection<SistemaDtoResponse>> ListarSistemasPorUsuario(LoginUsuarioDtoRequest request)
        {
            try
            {
                var queryString = $"?Usuario={request.Usuario}";
                var response = await HttpClient.GetAsync($"{BaseUrl}/ListarSistemasPorUsuario{queryString}");

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
