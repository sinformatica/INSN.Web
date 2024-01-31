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
    private readonly IWebHostEnvironment _enviroment;
    private readonly IDocumentoLegalProxy _proxy;
    private readonly ITipoDocumentoProxy _TipoDocumentoProxy;
    private readonly ILogger<UFGRDController> _logger;

    //private const int MaxFileSize = 4 * 1024 * 1024;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="proxy"></param>
    /// <param name="TipoDocumentoProxy"></param>
    /// <param name="logger"></param>
    public UFGRDController(IDocumentoLegalProxy proxy, ITipoDocumentoProxy TipoDocumentoProxy, ILogger<UFGRDController> logger, IWebHostEnvironment env)
    {
        _proxy = proxy;
       _TipoDocumentoProxy = TipoDocumentoProxy;
        _logger = logger;
        _enviroment = env;
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
            Area = "UFGRD",
            Estado = "A",
            EstadoRegistro = 1
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
            Area = "UFGRD",
            Estado = "A",
            EstadoRegistro = 1
        });

        return (List<DocumentoLegalDtoResponse>)resultDocumentoLegales;
    }

    //public IActionResult Download1(string fileName)
    //{
    //    try
    //    {
    //        var filePath = Path.Combine(_enviroment.ContentRootPath, "Documentos/NormasDocumentosLegales", fileName);

    //        if (!System.IO.File.Exists(filePath))
    //        {
    //            return NotFound(); // Manejo de archivo no encontrado
    //        }

    //        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

    //        return new FileStreamResult(fileStream, "application/pdf");
    //    }
    //    catch (Exception ex)
    //    {
    //        // Manejar cualquier otro tipo de error
    //        // Por ejemplo: Loggear el error para su revisión posterior
    //        return StatusCode(StatusCodes.Status500InternalServerError);
    //    }
    //}
}