using INSN.Web.Common;
using INSN.Web.Models.Request.Home.DocumentoLegal;
using INSN.Web.Models.Response.Home.DocumentoLegal;
using INSN.Web.Portal.Services.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.ViewModels.Home.DocumentoLegal;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Covid19
/// </summary>
public class Covid19Controller : Controller
{
    private readonly IDocumentoLegalProxy _proxy;
    private readonly ITipoDocumentoProxy _TipoDocumentoProxy;

    /// <summary>
    /// Covid19 Controller
    /// </summary>
    /// <param name="proxy"></param>
    /// <param name="TipoDocumentoProxy"></param>
    public Covid19Controller(IDocumentoLegalProxy proxy, ITipoDocumentoProxy TipoDocumentoProxy)
    {
        _proxy = proxy;
        _TipoDocumentoProxy = TipoDocumentoProxy;
    }

    /// <summary>
    /// Cargar Página Index
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<IActionResult> Index(DocumentoLegalViewModel model)
    {
        var resultTipoDocumento = await _TipoDocumentoProxy.TipoDocumentoListar(new TipoDocumentoDtoRequest()
        {
            Area = Enumerado.DocumentosLegales.Covid19,
            Estado = Enumerado.Estado.Activo,
            EstadoRegistro = 1
        });

        var resultDocumentoLegal = DocumentoLegalListar(model);
        resultDocumentoLegal.Wait();

        model.TipoDocumentos = resultTipoDocumento;
        model.DocumentoLegales = resultDocumentoLegal.Result;

        return View("~/Views/Home/Covid19/Index.cshtml", model);
    }

    /// <summary>
    /// Documento Legal Listar
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<List<DocumentoLegalDtoResponse>> DocumentoLegalListar(DocumentoLegalViewModel model)
    {
        var resultDocumentoLegales = await _proxy.DocumentoLegalListar(new DocumentoLegalDtoRequest()
        {
            Documento = model.Documento,
            Descripcion = model.Descripcion,
            CodigoTipoDocumentoId = model.TipoDocumentoSeleccionada,
            Area = Enumerado.DocumentosLegales.Covid19,
            Estado = Enumerado.Estado.Activo,
            EstadoRegistro = 1
        });

        return (List<DocumentoLegalDtoResponse>)resultDocumentoLegales;
    }    
}