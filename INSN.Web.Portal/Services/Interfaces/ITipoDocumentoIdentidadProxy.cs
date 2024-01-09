using INSN.Web.Models;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;

namespace INSN.Web.Portal.Services.Interfaces
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
