using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Analisis Situacional
/// </summary>
public class AnalisisSituacionalController : Controller
{
    /// <summary>
    /// Analisis Situacional Controller
    /// </summary>
    public AnalisisSituacionalController()
    {
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View("~/Views/Home/AnalisisSituacional/Index.cshtml");
    }
}