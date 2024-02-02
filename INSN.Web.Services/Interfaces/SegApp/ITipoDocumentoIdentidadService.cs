using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp;

namespace INSN.Web.Services.Interfaces.SegApp
{
    /// <summary>
    /// ITipoDocumentoIdentidadService
    /// </summary>
    public interface ITipoDocumentoIdentidadService
    {
        /// <summary>
        /// Tipo Documento Identidad Listar
        /// </summary>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<TipoDocumentoIdentidadDtoResponse>>> TipoDocumentoIdentidadListar();
    }
}