using INSN.Web.Models.Request.Home.Anuncios;
using INSN.Web.Models.Response.Home.Anuncios;

namespace INSN.Web.Portal.Services.Interfaces.Home.Anuncios
{
    /// <summary>
    /// IProxy: IAnuncio Proxy
    /// </summary>
    public interface IAnuncioProxy : ICrudRestHelper<AnuncioDtoRequest, AnuncioDtoResponse>
    {
        /// <summary>
        /// IProxy: Anuncio Listar
        /// </summary>
        /// <returns></returns>
        Task<ICollection<AnuncioDtoResponse>> AnuncioListar(AnuncioDtoRequest request);
    }
}