using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Lactancia Materna
/// </summary>
public class LactanciaMaternaController : Controller
{
    /// <summary>
    /// Lactancia Materna Controller
    /// </summary>
    public LactanciaMaternaController()
    {
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View("~/Views/Home/LactanciaMaterna/Index.cshtml");
    }
}