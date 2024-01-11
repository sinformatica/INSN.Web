using INSN.Web.Models;
using INSN.Web.Models.Request;
//using INSN.Web.Portal.Services.Interfaces.Home.OportunidadLaboral;
using INSN.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace INSN.Web.Portal.Controllers.Home;

public class GestionCalidadController : Controller
{
    private readonly IWebHostEnvironment _enviroment;
  //  private readonly IDocumentoLegalProxy _proxy;
  //  private readonly ITipoDocumentoProxy _TipoDocumentoProxy;
    private readonly ILogger<GestionCalidadController> _logger;

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="proxy"></param>
    /// <param name="TipoDocumentoProxy"></param>
    /// <param name="logger"></param>
    public GestionCalidadController(//IDocumentoLegalProxy proxy, ITipoDocumentoProxy TipoDocumentoProxy,
        ILogger<GestionCalidadController> logger, IWebHostEnvironment env)
    {
       // _proxy = proxy;
     //   _TipoDocumentoProxy = TipoDocumentoProxy;
        _logger = logger;
        _enviroment = env;
    }

    public IActionResult Index()
    {
        return View("~/Views/Home/GestionCalidad/Index.cshtml");
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
    //}


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