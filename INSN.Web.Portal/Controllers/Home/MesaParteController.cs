using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Mesa Parte
/// </summary>
public class MesaParteController : Controller
{
    /// <summary>
    /// Mesa Parte Controller
    /// </summary>
    public MesaParteController()
    {
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View("~/Views/Home/MesaParte/Index.cshtml");
    }
}