using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Gestion Calidad
/// </summary>
public class GestionCalidadController : Controller
{
    /// <summary>
    /// Gestion Calidad Controller
    /// </summary>
    public GestionCalidadController()
    {
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View("~/Views/Home/GestionCalidad/Index.cshtml");
    }
}