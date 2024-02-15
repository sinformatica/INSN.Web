using INSN.Web.Models.Request.Home.Noticias;
using INSN.Web.Models.Response.Home.Noticias;

namespace INSN.Web.Portal.Services.Interfaces.Home.Noticias
{
    /// <summary>
    /// Interface Noticia
    /// </summary>
    public interface INoticiaProxy : ICrudRestHelper<NoticiaDtoRequest, NoticiaDtoResponse>
    {
        #region[Noticia]
        /// <summary>
        /// IProxy: Noticia Listar
        /// </summary>
        /// <returns></returns>
        Task<ICollection<NoticiaDtoResponse>> NoticiaListar(NoticiaDtoRequest request);
        #endregion

        #region[Noticia Detalle]
        /// <summary>
        /// IProxy: Noticia Detalle Listar
        /// </summary>
        /// <param name="CodigoNoticiaId"></param>
        /// <returns></returns>
        Task<ICollection<NoticiaDetalleDtoResponse>> NoticiaDetalleListar(int CodigoNoticiaId);
        #endregion
    }
}