using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento;
using System.Net.Http.Headers;
using INSN.Web.Common;

namespace INSN.Web.Portal.Services.Implementaciones.SegApp.Mantenimiento
{
    /// <summary>
    /// Proxy: Rol
    /// </summary>
    public class RolProxy : CrudRestHelperBase<RolDtoRequest, RolDtoResponse>, IRolProxy
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;

        /// <summary>
        /// Inicializar
        /// <param name="httpClient"></param>
        /// <param name="httpContextAccessor"></param>
        /// </summary>
        public RolProxy(HttpClient httpClient, IHttpContextAccessor httpContextAccessor) 
            : base("api/SegApp/Mantenimiento/Rol", httpClient)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

            // Configurar la cabecera de autorización con el token
            string token = _httpContextAccessor?.HttpContext?.Session.GetString(Constantes.JwtToken) ?? string.Empty;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        /// <summary>
        /// Proxy: Rol Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ICollection<RolDtoResponse>> RolListar(RolDtoRequest request)
        {
            try
            {
                var queryString = $"?Name={request.Name}&Estado={request.Estado}";
                var response = await HttpClient.GetAsync($"{BaseUrl}/RolListar{queryString}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<RolDtoResponse>>>();

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
        /// Proxy: Rol Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task RolInsertar(RolDtoRequest request)
        {
            var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}/RolInsertar", request);
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
        /// Proxy: Rol Buscar Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<RolDtoResponse> RolBuscarId(string? id)
        {
            var response = await HttpClient.GetFromJsonAsync<BaseResponseGeneric<RolDtoResponse>>($"{BaseUrl}/RolBuscarId/{id}");
            if (response!.Success)
            {
                return response.Data!;
            }

            throw new InvalidOperationException(response.ErrorMessage);
        }

        /// <summary>
        /// Proxy: Rol Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task RolActualizar(RolDtoRequest request)
        {
            var response = await HttpClient.PutAsJsonAsync($"{BaseUrl}/RolActualizar/", request);
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
        /// Proxy: Rol Eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task RolEliminar(string id)
        {
            var response = await HttpClient.DeleteAsync($"{BaseUrl}/RolEliminar/{id}");
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
        /// Proxy: Rol Por Sistema Listar
        /// </summary>
        /// <param name="CodigoSistemaId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ICollection<RolDtoResponse>> RolPorSistemaListar(int CodigoSistemaId)
        {
            try
            {
                var response = await HttpClient.GetAsync($"{BaseUrl}/RolPorSistemaListar/{CodigoSistemaId}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<RolDtoResponse>>>();

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