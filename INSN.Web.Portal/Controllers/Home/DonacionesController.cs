using INSN.Web.ViewModels.Home.DocumentoLegal;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Donaciones
/// </summary>
public class DonacionesController : Controller
{
    /// <summary>
    /// Donaciones Controller
    /// </summary>
    public DonacionesController()
    {
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View("~/Views/Home/Donaciones/Index.cshtml");
    }
}