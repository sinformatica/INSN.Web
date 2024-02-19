using INSN.Web.Models.Request.Home.Noticias;
using INSN.Web.Models.Response.Home.Noticias;
using INSN.Web.Models.Response;
using INSN.Web.Portal.Services.Interfaces.Home.Noticias;

namespace INSN.Web.Portal.Services.Implementaciones.Home.Noticias
{
    /// <summary>
    /// Clase Proxy Noticia
    /// </summary>
    public class NoticiaProxy : CrudRestHelperBase<NoticiaDtoRequest, NoticiaDtoResponse>, INoticiaProxy
    {
        /// <summary>
        /// Noticia Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        /// /// <param name="httpContextAccessor"></param>
        public NoticiaProxy(HttpClient httpClient, IHttpContextAccessor? httpContextAccessor)
        : base("api/Noticia", httpClient)
        {
        }

        #region[Noticia]
        /// <summary>
        /// Proxy: Noticia Listar
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ICollection<NoticiaDtoResponse>> NoticiaListar(NoticiaDtoRequest request)
        {
            try
            {
                var queryString = $"?Titulo={request.Titulo}&FechaExpiracion={request.FechaExpiracion.ToString("yyyy-MM-dd")}&Estado={request.Estado}&EstadoRegistro={request.EstadoRegistro}";
                var response = await HttpClient.GetAsync($"{BaseUrl}/NoticiaListar{queryString}");
                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<NoticiaDtoResponse>>>();

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
        #endregion

        #region[Noticia Detalle]
        /// <summary>
        ///  Proxy: Noticia Detalle Listar
        /// </summary>
        /// <param name="CodigoNoticiaId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ICollection<NoticiaDetalleDtoResponse>> NoticiaDetalleListar(int CodigoNoticiaId)
        {
            try
            {
                var response = await HttpClient.GetAsync($"{BaseUrl}/NoticiaDetalleListar/{CodigoNoticiaId}");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<NoticiaDetalleDtoResponse>>>();

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
        #endregion
    }
}