using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Mantenimiento.DocumentoLegal;

namespace INSN.Web.Services.Interfaces.Mantenimiento.DocumentoInstitucional
{
    /// <summary>
    /// Interface Servicio Tipo Documento
    /// </summary>
    public interface ITipoDocumentoService
    {
        /// <summary>
        /// Interface de Listar Tipo Documento
        /// </summary>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<TipoDocumentoDtoResponse>>> TipoDocumentoListar(TipoDocumentoDtoRequest request);
    }
}