using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp;

namespace INSN.Web.Services.Interfaces.SegApp
{
    public interface ITipoDocumentoIdentidadService
    {
        /// <summary>
        /// Tipo Documento Identidad Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<TipoDocumentoIdentidadDtoResponse>>> TipoDocumentoIdentidadListar();
    }
}