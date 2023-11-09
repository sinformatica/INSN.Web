using INSN.Web.Models;
using INSN.Web.Models.Request;
using INSN.Web.Portal.Services.Interfaces;
using INSN.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers;

public class DocumentoLegalController : Controller
{
    private readonly IDocumentoLegalProxy _proxy;
    private readonly ITipoDocumentoProxy _TipoDocumentoProxy;
    private readonly ILogger<DocumentoLegalController> _logger;

    private const int MaxFileSize = 4 * 1024 * 1024;

    public DocumentoLegalController(IDocumentoLegalProxy proxy, ITipoDocumentoProxy TipoDocumentoProxy, ILogger<DocumentoLegalController> logger)
    {
        _proxy = proxy;
        _TipoDocumentoProxy = TipoDocumentoProxy;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    // GET
    public async Task<IActionResult> DocumentoLegal(DocumentoLegalViewModel model)
    {
        PaginationData pager = ViewBag.Pager != null
            ? ViewBag.Pager
            : new PaginationData();

        if (pager.CurrentPage == 0)
            pager.CurrentPage = model.Page <= 0 ? 1 : model.Page;

        pager.RowsPerPage = model.Rows <= 0 ? 5 : model.Rows;

        model.TipoDocumentos = await _TipoDocumentoProxy.ListAsync();

        var response = await _proxy.ListAsync(new BusquedaDocumentoLegalRequest()
        {
            Filter = model.Documento,
            TipoDocumentoId = model.TipoDocumentoSeleccionada,
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

        return View(model);
    }

    //public async Task<IActionResult> Crear()
    //{
    //    var vm = new FormDocumentoLegalViewModel
    //    {
    //        TipoDocumentos = await _TipoDocumentoProxy.ListAsync(),
    //        Input = new DocumentoLegalDtoRequest
    //        {
    //            FechaInicio = DateTime.Today,
    //            HoraInicio = DateTime.Now
    //        }
    //    };

    //    vm.BusquedaInstructorViewModel.TipoDocumentos = vm.TipoDocumentos;

    //    return View(vm);
    //}

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Crear(FormDocumentoLegalViewModel model)
    //{
    //    // Primero obtenemos los archivos
    //    var archivos = HttpContext.Request.Form.Files;

    //    try
    //    {
    //        if (archivos.Any() && archivos.Count == 2)
    //        {
    //            var portada = archivos[0];
    //            var temario = archivos[1];

    //            if (portada.Length > MaxFileSize) // 4MB
    //            {
    //                throw new InvalidOperationException("La imagen de la portada no puede ser mayor a 4MB");
    //            }

    //            using (var memoryStream = new MemoryStream())
    //            {
    //                await portada.CopyToAsync(memoryStream);

    //                model.Input.Base64Portada = Convert.ToBase64String(memoryStream.ToArray());
    //                model.Input.ArchivoPortada = portada.FileName;
    //            }

    //            using (var memoryStream = new MemoryStream())
    //            {
    //                await temario.CopyToAsync(memoryStream);

    //                model.Input.Base64Temario = Convert.ToBase64String(memoryStream.ToArray());
    //                model.Input.ArchivoTemario = temario.FileName;
    //            }
                
    //        }

    //        await _proxy.CreateAsync(model.Input);

    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogCritical(ex, "Error al registrar el DocumentoLegal {Message}", ex.Message);

    //        model.TipoDocumentos = await _TipoDocumentoProxy.ListAsync();
    //        model.BusquedaInstructorViewModel.TipoDocumentos = model.TipoDocumentos;
            
    //        ModelState.AddModelError("Error", ex.Message);
    //        return View(nameof(Crear), model);
    //    }
    //}
}