using INSN.Web.Portal.Services.Interfaces.SegApp;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Request.Home;
using INSN.Web.ViewModels.Home.LibroReclamacion;

namespace INSN.Web.Portal.Controllers.Home;

public class LibroReclamacionController : Controller
{
    private readonly IWebHostEnvironment _enviroment;
    private readonly ILogger<LibroReclamacionController> _logger;
    private readonly ITipoDocumentoIdentidadProxy _proxyTipoDocumentoIdentidad;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="proxy"></param>
    /// <param name="TipoDocumentoProxy"></param>
    /// <param name="logger"></param>
    public LibroReclamacionController(ITipoDocumentoIdentidadProxy TipoDocumentoIdentidad, ILogger<LibroReclamacionController> logger, IWebHostEnvironment env)
    {
       // _proxy = proxy;
        _proxyTipoDocumentoIdentidad = TipoDocumentoIdentidad;
        _logger = logger;
        _enviroment = env;
    }


    /// <summary>
    /// Cargar Página Index
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<IActionResult> Index(LibroReclamacionViewModel model)
    {
        var resultTiposDocumentos = await _proxyTipoDocumentoIdentidad.TipoDocumentoIdentidadListar(new TipoDocumentoIdentidadDtoRequest()
        {         
            Estado = "A",
            EstadoRegistro = 1
        });

        model.TiposDocumentosIdentidad = resultTiposDocumentos;

        return View("~/Views/Home/LibroReclamaciones/Index.cshtml", model);
    } 
}

