using INSN.Web.Models;
using INSN.Web.Models.Request;
using INSN.Web.Portal.Services.Interfaces.Home.DirectorioInstitucional;

//using INSN.Web.Portal.Services.Interfaces.Home.UFGRD;
using INSN.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace INSN.Web.Portal.Controllers.Home;

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

    // GET
    /// <summary>
    /// Modelo del Documento Legal
    /// </summary>
    /// <param name="model"></param>
    ///// <returns></returns>

    public async Task<IActionResult> DocumentoLegalUFGRD(DocumentoLegalViewModel model)
    {
        PaginationData pager = ViewBag.Pager != null
            ? ViewBag.Pager
            : new PaginationData();

        if (pager.CurrentPage == 0)
            pager.CurrentPage = model.Page <= 0 ? 1 : model.Page;

        pager.RowsPerPage = model.Rows <= 0 ? 20 : model.Rows;

        //model.TipoDocumentos = await _TipoDocumentoProxy.TipoDocumentoListar("UFGRD", "A", 1);

        //var response = await _proxy.ListAsync(new BusquedaDocumentoLegalRequest()
        //{
        //    Documento = model.Documento,
        //    Descripcion = model.Descripcion,
        //    Area = "UFGRD",
        //    TipoDocumentoId = model.TipoDocumentoSeleccionada,
        //    Estado = model.EstadoSeleccionado,
        //    EstadoRegistro = 1,
        //    Page = pager.CurrentPage,
        //    Rows = pager.RowsPerPage
        //});

        //ViewBag.Pager = pager;

        //if (response.Success)
        //{
        //    model.DocumentoLegales = response.Data;
        //    pager.TotalPages = response.TotalPages;
        //    pager.RowCount = response.Data!.Count;
        //}

        return View("~/Views/Home/UFGRD/Index.cshtml", model);
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