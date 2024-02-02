using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Response.SegApp;

namespace INSN.Web.Portal.Services.Interfaces.SegApp
{
    /// <summary>
    /// ITipoDocumentoIdentidadProxy
    /// </summary>
    public interface ITipoDocumentoIdentidadProxy : ICrudRestHelper<TipoDocumentoIdentidadDtoRequest, TipoDocumentoIdentidadDtoResponse>
    {
        /// <summary>
        /// IProxy: Tipo Documento Identidad Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<TipoDocumentoIdentidadDtoResponse>> TipoDocumentoIdentidadListar(TipoDocumentoIdentidadDtoRequest request);
    }
}