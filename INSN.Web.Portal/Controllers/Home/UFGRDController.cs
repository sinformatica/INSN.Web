using INSN.Web.Common;
using INSN.Web.Models.Request.Home.DocumentoLegal;
using INSN.Web.Models.Response.Home.DocumentoLegal;
using INSN.Web.Portal.Services.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.ViewModels.Home.DocumentoLegal;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador UFGRD
/// </summary>
public class UFGRDController : Controller
{
    private readonly IDocumentoLegalProxy _proxy;
    private readonly ITipoDocumentoProxy _TipoDocumentoProxy;

    /// <summary>
    /// UFGRD Controller
    /// </summary>
    /// <param name="proxy"></param>
    /// <param name="TipoDocumentoProxy"></param>
    public UFGRDController(IDocumentoLegalProxy proxy, ITipoDocumentoProxy TipoDocumentoProxy)
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
            Area = Enumerado.DocumentosLegales.UFGRD,
            Estado = Enumerado.Estado.Activo,
            EstadoRegistro = Enumerado.EstadoRegistro.Activo
        });

        var resultDocumentoLegal = DocumentoLegalListar(model);
        resultDocumentoLegal.Wait();

        model.TipoDocumentos = resultTipoDocumento;
        model.DocumentoLegales = resultDocumentoLegal.Result;

        return View("~/Views/Home/UFGRD/Index.cshtml", model);
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
            Area = Enumerado.DocumentosLegales.UFGRD,
            Estado = Enumerado.Estado.Activo,
            EstadoRegistro = Enumerado.EstadoRegistro.Activo
        });

        return (List<DocumentoLegalDtoResponse>)resultDocumentoLegales;
    }
}