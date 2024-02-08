using INSN.Web.Common;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace INSN.Web.Portal.Services.Implementaciones.SegApp.Mantenimiento
{
    /// <summary>
    /// Usuario Proxy
    /// </summary>
    public class UsuarioProxy : CrudRestHelperBase<UsuarioDtoRequest, UsuarioDtoResponse>, IUsuarioProxy
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="httpContextAccessor"></param>
        public UsuarioProxy(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            : base("api/SegApp/Mantenimiento/Usuario", httpClient)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
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
        /// Proxy: Usuario Validar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<string> UsuarioValidar(UsuarioDtoRequest request)
        {
            var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}/UsuarioValidar", request);
            var resultado = await response.Content.ReadFromJsonAsync<BaseResponseGeneric<string>>();

            return resultado?.Data ?? string.Empty;
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
                    BaseResponse errorResponse = JsonConvert.DeserializeObject<BaseResponse>(errorMessage);
                    string errorText = errorResponse.ErrorMessage ?? string.Empty;

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

        /// <summary>
        /// Proxy: Usuario Buscar Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<UsuarioDtoResponse> UsuarioBuscarId(string? id)
        {
            var response = await HttpClient.GetFromJsonAsync<BaseResponseGeneric<UsuarioDtoResponse>>($"{BaseUrl}/UsuarioBuscarId/{id}");
            if (response!.Success)
            {
                return response.Data!;
            }

            throw new InvalidOperationException(response.ErrorMessage);
        }

        /// <summary>
        /// Proxy: Usuario Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task UsuarioActualizar(UsuarioDtoRequest request)
        {
            var response = await HttpClient.PutAsJsonAsync($"{BaseUrl}/UsuarioActualizar/", request);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    BaseResponse errorResponse = JsonConvert.DeserializeObject<BaseResponse>(errorMessage);
                    string errorText = errorResponse.ErrorMessage ?? string.Empty;

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

        /// <summary>
        /// Proxy: Usuario Eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task UsuarioEliminar(string id)
        {
            var response = await HttpClient.DeleteAsync($"{BaseUrl}/UsuarioEliminar/{id}");
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

        /// <summary>
        /// Proxy: Usuario Actualizar Clave
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task UsuarioActualizarClave(UsuarioDtoRequest request)
        {
            var response = await HttpClient.PutAsJsonAsync($"{BaseUrl}/UsuarioActualizarClave/", request);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    BaseResponse errorResponse = JsonConvert.DeserializeObject<BaseResponse>(errorMessage);
                    string errorText = errorResponse.ErrorMessage ?? string.Empty;

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