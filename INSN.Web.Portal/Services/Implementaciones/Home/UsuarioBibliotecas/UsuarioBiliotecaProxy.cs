using INSN.Web.Models.Request.Home.UsuarioBibliotecas;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home.UsuarioBibliotecas;
using INSN.Web.Portal.Services.Interfaces.Home.UsuarioBibliotecas;

namespace INSN.Web.Portal.Services.Implementaciones.Home.UsuarioBibliotecas
{
    /// <summary>
    /// Clase Proxy Usuario Biblioteca
    /// </summary>
    public class UsuarioBibliotecaProxy : CrudRestHelperBase<UsuarioBibliotecaDtoRequest, UsuarioBibliotecaDtoResponse>, IUsuarioBibliotecaProxy
    {
        /// <summary>
        /// Usuario Biblioteca Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="httpContextAccessor"></param>
        public UsuarioBibliotecaProxy(HttpClient httpClient, IHttpContextAccessor? httpContextAccessor)
        : base("api/Mantenimiento/UsuarioBiblioteca", httpClient)
        {
        }

        /// <summary>
        /// Proxy: UsuarioBiblioteca Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ICollection<UsuarioBibliotecaDtoResponse>> UsuarioBibliotecaListar(UsuarioBibliotecaDtoRequest request)
        {
            try
            {
                var queryString = $"?Estado={request.Estado}&EstadoRegistro={request.EstadoRegistro}";
                var response = await HttpClient.GetAsync($"{BaseUrl}/UsuarioBibliotecaListar{queryString}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<UsuarioBibliotecaDtoResponse>>>();

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
        /// Proxy: Usuario Biblioteca Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<int> UsuarioBibliotecaInsertar(UsuarioBibliotecaDtoRequest request)
        {
            var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}/UsuarioBibliotecaInsertar", request);

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
                if (resultado!.Success == false) throw new InvalidOperationException(resultado.ErrorMessage);

                return resultado.Id;
            }
            else
            {
                throw new InvalidOperationException(response.ReasonPhrase);
            }
        }
    }
}