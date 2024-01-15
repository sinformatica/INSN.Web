using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento;
using Newtonsoft.Json;

namespace INSN.Web.Portal.Services.Implementaciones.SegApp.Mantenimiento
{
    public class UsuarioRolProxy : CrudRestHelperBase<UsuarioRolDtoRequest, UsuarioRolDtoResponse>, IUsuarioRolProxy
    {
        /// <summary>
        /// Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        public UsuarioRolProxy(HttpClient httpClient)
            : base("api/SegApp/Mantenimiento/UsuarioRol", httpClient)
        {
        }

        /// <summary>
        /// Proxy: Rol Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ICollection<UsuarioRolDtoResponse>> UsuarioRolListar(string UserId)
        {
            try
            {
                var response = await HttpClient.GetAsync($"{BaseUrl}/UsuarioRolListar/{UserId}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<UsuarioRolDtoResponse>>>();

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
        /// Proxy: Usuario Rol Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task UsuarioRolInsertar(UsuarioRolDtoRequest request)
        {
            var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}/UsuarioRolInsertar", request);

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

        /// <summary>
        /// Proxy: Usuario Rol Eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task UsuarioRolEliminar(int id)
        {
            var response = await HttpClient.DeleteAsync($"{BaseUrl}/UsuarioRolEliminar/{id}");
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
    }
}
