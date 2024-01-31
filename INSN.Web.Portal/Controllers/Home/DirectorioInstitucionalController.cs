using INSN.Web.Models.Request.Home.DocumentoLegal;
using INSN.Web.Portal.Services.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.ViewModels.Home.DocumentoLegal;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Directorio Institucional
/// </summary>
public class DirectorioInstitucionalController : Controller
{
    private readonly IWebHostEnvironment _enviroment;
    private readonly IDocumentoLegalProxy _proxy;
    private readonly ITipoDocumentoProxy _TipoDocumentoProxy;
    private readonly ILogger<DirectorioInstitucionalController> _logger;

    /// <summary>
    /// DirectorioInstitucionalController
    /// </summary>
    /// <param name="proxy"></param>
    /// <param name="TipoDocumentoProxy"></param>
    /// <param name="logger"></param>
    public DirectorioInstitucionalController(IDocumentoLegalProxy proxy, ITipoDocumentoProxy TipoDocumentoProxy, ILogger<DirectorioInstitucionalController> logger, IWebHostEnvironment env)
    {
        _proxy = proxy;
        _TipoDocumentoProxy = TipoDocumentoProxy;
        _logger = logger;
        _enviroment = env;
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View("~/Views/Home/DirectorioInstitucional/Index.cshtml");
    }

    /// <summary>
    /// Documento Legal Listar
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<IActionResult> DocumentoLegal(DocumentoLegalViewModel model)
    {
        var resultDocumentoLegales = await _proxy.DocumentoLegalListar(new DocumentoLegalDtoRequest()
        {
            Documento = model.Documento,
            Descripcion = model.Descripcion,
            CodigoTipoDocumentoId = model.TipoDocumentoSeleccionada,
            Area = "DOCUMENTOLEGAL",
            Estado = "A",
            EstadoRegistro = 1
        });

        model.DocumentoLegales = resultDocumentoLegales;
        model.TituloPagina = model.TituloPagina;

        return View("~/Views/Home/DirectorioInstitucional/DocumentoLegal.cshtml", model);
    }
}