using INSN.Web.Models;
using INSN.Web.Models.Request;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Interfaces;
using INSN.Web.Portal.Services.Interfaces.Home.DirectorioInstitucional;

namespace INSN.Web.Portal.Services.Implementaciones
{
    public class TipoDocumentoIdentidadProxy : CrudRestHelperBase<TipoDocumentoIdentidadDtoRequest, TipoDocumentoIdentidadDtoResponse>, ITipoDocumentoIdentidadProxy
    {
        /// <summary>
        /// Proxy
        /// </summary>
        /// <param name="httpClient"></param>
        public TipoDocumentoIdentidadProxy(HttpClient httpClient)
        : base("api/TipoDocumentoIdentidad", httpClient)
        {
        }

        /// <summary>
        /// Proxy: Tipo Documento Identidad Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<TipoDocumentoIdentidadDtoResponse>> TipoDocumentoIdentidadListar(TipoDocumentoIdentidadDtoRequest request)
        {
            try
            {
                var response = await HttpClient.GetAsync($"{BaseUrl}/TipoDocumentoIdentidadListar");

                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<TipoDocumentoIdentidadDtoResponse>>>();

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
    }
}
