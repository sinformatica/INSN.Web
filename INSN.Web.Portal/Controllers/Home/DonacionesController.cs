using INSN.Web.Models;
using INSN.Web.Models.Request;
<<<<<<< Updated upstream:INSN.Web.Portal/Controllers/Home/DonacionesController.cs
//using INSN.Web.Portal.Services.Interfaces.Home.OportunidadLaboral;
=======
using INSN.Web.Portal.Services.Interfaces.Home.DirectorioInstitucional;

//using INSN.Web.Portal.Services.Interfaces.Home.Covid19;
>>>>>>> Stashed changes:INSN.Web.Portal/Controllers/Home/Covid19.cs
using INSN.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace INSN.Web.Portal.Controllers.Home;

public class DonacionesController : Controller
{
    private readonly IWebHostEnvironment _enviroment;
<<<<<<< Updated upstream:INSN.Web.Portal/Controllers/Home/DonacionesController.cs
  //  private readonly IDocumentoLegalProxy _proxy;
  //  private readonly ITipoDocumentoProxy _TipoDocumentoProxy;
    private readonly ILogger<DonacionesController> _logger;
=======
    private readonly IDocumentoLegalProxy _proxy;
    private readonly ITipoDocumentoProxy _TipoDocumentoProxy;
    private readonly ILogger<Covid19Controller> _logger;

    //private const int MaxFileSize = 4 * 1024 * 1024;
>>>>>>> Stashed changes:INSN.Web.Portal/Controllers/Home/Covid19.cs

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="proxy"></param>
    /// <param name="TipoDocumentoProxy"></param>
    /// <param name="logger"></param>
<<<<<<< Updated upstream:INSN.Web.Portal/Controllers/Home/DonacionesController.cs
    public DonacionesController(//IDocumentoLegalProxy proxy, ITipoDocumentoProxy TipoDocumentoProxy,
        ILogger<DonacionesController> logger, IWebHostEnvironment env)
=======
    public Covid19Controller(IDocumentoLegalProxy proxy, ITipoDocumentoProxy TipoDocumentoProxy, ILogger<Covid19Controller> logger, IWebHostEnvironment env)
>>>>>>> Stashed changes:INSN.Web.Portal/Controllers/Home/Covid19.cs
    {
        _proxy = proxy;
        _TipoDocumentoProxy = TipoDocumentoProxy;
        _logger = logger;
        _enviroment = env;
    }

<<<<<<< Updated upstream:INSN.Web.Portal/Controllers/Home/DonacionesController.cs
    public IActionResult Index()
    {
        return View("~/Views/Home/Donaciones/Index.cshtml");
    }

    //// GET
    ///// <summary>
    ///// Modelo del Documento Legal
    ///// </summary>
    ///// <param name="model"></param>
    ///// <returns></returns>
    //public async Task<IActionResult> DocumentoLegal(DocumentoLegalViewModel model)
    //{
    //    PaginationData pager = ViewBag.Pager != null
    //        ? ViewBag.Pager
    //        : new PaginationData();

    //    if (pager.CurrentPage == 0)
    //        pager.CurrentPage = model.Page <= 0 ? 1 : model.Page;

    //    pager.RowsPerPage = model.Rows <= 0 ? 20 : model.Rows;

    //    model.TipoDocumentos = await _TipoDocumentoProxy.ListAsync();

    //    var response = await _proxy.ListAsync(new BusquedaDocumentoLegalRequest()
    //    {
    //        Documento = model.Documento,
    //        Descripcion=model.Descripcion,
    //        TipoDocumentoId = model.TipoDocumentoSeleccionada,
    //        Estado = model.EstadoSeleccionado,
    //        Page = pager.CurrentPage,
    //        Rows = pager.RowsPerPage
    //    });

    //    ViewBag.Pager = pager;

    //    if (response.Success)
    //    {
    //        model.DocumentoLegales = response.Data;
    //        pager.TotalPages = response.TotalPages;
    //        pager.RowCount = response.Data!.Count;
    //    }

    //    return View("~/Views/Home/OportunidadLaboral/DocumentoLegal.cshtml", model);
=======
    //public IActionResult Index()
    //{
    //    return View("~/Views/Home/Covid19/Index.cshtml");
>>>>>>> Stashed changes:INSN.Web.Portal/Controllers/Home/Covid19.cs
    //}

    // GET
    /// <summary>
    /// Modelo del Documento Legal
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<IActionResult> DocumentoLegalCovid19(DocumentoLegalViewModel model)
    {
        PaginationData pager = ViewBag.Pager != null
            ? ViewBag.Pager
            : new PaginationData();

        if (pager.CurrentPage == 0)
            pager.CurrentPage = model.Page <= 0 ? 1 : model.Page;

        pager.RowsPerPage = model.Rows <= 0 ? 20 : model.Rows;

        model.TipoDocumentos = await _TipoDocumentoProxy.ListAsync();

        var response = await _proxy.ListAsync(new BusquedaDocumentoLegalRequest()
        {
            Documento = model.Documento,
            Descripcion = model.Descripcion,
            TipoDocumentoId = 1 /*model.TipoDocumentoSeleccionada*/,
            Estado = model.EstadoSeleccionado,
            Page = pager.CurrentPage,
            Rows = pager.RowsPerPage
        });
        
        ViewBag.Pager = pager;

        if (response.Success)
        {
            model.DocumentoLegales = response.Data;
            pager.TotalPages = response.TotalPages;
            pager.RowCount = response.Data!.Count;
        }

        return View("~/Views/Home/Covid19/Index.cshtml", model);
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