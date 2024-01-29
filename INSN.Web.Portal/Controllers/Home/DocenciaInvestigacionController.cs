using INSN.Web.Models.Request.Home;
using INSN.Web.Portal.Models;
using INSN.Web.Portal.Services.Interfaces.Mantenimiento.DocumentoInstitucional;
using INSN.Web.ViewModels.Home.DocumentoLegal;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace INSN.Web.Portal.Controllers.Home;

public class DocenciaInvestigacionController : Controller
{
    private readonly IWebHostEnvironment _enviroment;
    private readonly IDocumentoLegalProxy _proxy;
    private readonly ITipoDocumentoProxy _TipoDocumentoProxy;
    private readonly ILogger<DocenciaInvestigacionController> _logger;

    private const int MaxFileSize = 4 * 1024 * 1024;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="proxy"></param>
    /// <param name="TipoDocumentoProxy"></param>
    /// <param name="logger"></param>
    public DocenciaInvestigacionController(IDocumentoLegalProxy proxy, ITipoDocumentoProxy TipoDocumentoProxy, ILogger<DocenciaInvestigacionController> logger, IWebHostEnvironment env)
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
        return View("~/Views/Home/DocenciaInvestigacion/Index.cshtml");
    }


    #region [Investigacion]
    public IActionResult Investigacion()
    {
        return View("~/Views/Home/DocenciaInvestigacion/Investigacion/Investigacion.cshtml");
    }
    #endregion

    #region [Docencia]
    public IActionResult Docencia()
    {
        return View("~/Views/Home/DocenciaInvestigacion/Docencia/Docencia.cshtml");
    }
    #endregion

    #region [ComiteEtica]
    public IActionResult ComiteEtica()
    {
        return View("~/Views/Home/DocenciaInvestigacion/ComiteEtica/ComiteEtica.cshtml");
    }
    #endregion


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

