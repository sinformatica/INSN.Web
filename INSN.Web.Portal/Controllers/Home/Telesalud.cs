using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Tele Salud
/// </summary>
public class TelesaludController : Controller
{
    /// <summary>
    /// Telesalud Controller
    /// </summary>
    public TelesaludController()
    {
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View("~/Views/Home/Telesalud/Index.cshtml");
    }
}