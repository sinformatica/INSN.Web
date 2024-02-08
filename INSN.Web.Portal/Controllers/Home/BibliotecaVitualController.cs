using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Biblioteca Virtual
/// </summary>
public class BibliotecaVirtualController : Controller
{
    /// <summary>
    /// Biblioteca Virtual Controller
    /// </summary>
    public BibliotecaVirtualController()
    {
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View("~/Views/Home/BibliotecaVirtual/Index.cshtml");
    }
}