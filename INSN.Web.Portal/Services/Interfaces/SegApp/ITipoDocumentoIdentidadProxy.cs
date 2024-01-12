using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp;
using INSN.Web.Models.Response.SegApp.Mantenimiento;

namespace INSN.Web.Portal.Services.Interfaces.SegApp
{
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
