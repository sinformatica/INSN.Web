using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento;
using Newtonsoft.Json;

namespace INSN.Web.Portal.Services.Implementaciones.SegApp.Mantenimiento
{
    public class UsuarioProxy : CrudRestHelperBase<UsuarioDtoRequest, UsuarioDtoResponse>, IUsuarioProxy
    {
        /// <summary>
        /// Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        public UsuarioProxy(HttpClient httpClient)
            : base("api/SegApp/Mantenimiento/Usuario", httpClient)
        {
        }

        /// <summary>
        /// Proxy: Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ICollection<UsuarioDtoResponse>> UsuarioListar(UsuarioDtoRequest request)
        {
            try
            {
                var queryString = $"?Nombres={request.Nombres}&Estado={request.Estado}";
                var response = await HttpClient.GetAsync($"{BaseUrl}/UsuarioListar{queryString}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<UsuarioDtoResponse>>>();

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
        /// Proxy: Usuario Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task UsuarioInsertar(UsuarioDtoRequest request)
        {
            var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}/UsuarioInsertar", request);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    // Deserializar el JSON a la clase ErrorResponse
                    BaseResponse errorResponse = JsonConvert.DeserializeObject<BaseResponse>(errorMessage);

                    // Acceder a la propiedad errorMessage
                    string errorText = errorResponse.ErrorMessage;

                    throw new InvalidOperationException(errorText);
                }
                else
                {
                    throw new InvalidOperationException(response.ReasonPhrase);
                }
            }
            else
            {
                var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();

                if (resultado != null && resultado.Success == false)
                {
                    throw new InvalidOperationException(resultado.ErrorMessage);
                }
            }
        }

    }
}
