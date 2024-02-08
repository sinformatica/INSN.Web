using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Docencia Investigacion
/// </summary>
public class DocenciaInvestigacionController : Controller
{
    /// <summary>
    /// Docencia Investigacion Controller
    /// </summary>
    public DocenciaInvestigacionController()
    {
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View("~/Views/Home/DocenciaInvestigacion/Index.cshtml");
    }

    #region [Investigacion]
    /// <summary>
    /// Investigacion
    /// </summary>
    /// <returns></returns>
    public IActionResult Investigacion()
    {
        return View("~/Views/Home/DocenciaInvestigacion/Investigacion/Investigacion.cshtml");
    }
    #endregion

    #region [Docencia]
    /// <summary>
    /// Docencia
    /// </summary>
    /// <returns></returns>
    public IActionResult Docencia()
    {
        return View("~/Views/Home/DocenciaInvestigacion/Docencia/Docencia.cshtml");
    }
    #endregion

    #region [ComiteEtica]
    /// <summary>
    /// Comite Etica
    /// </summary>
    /// <returns></returns>
    public IActionResult ComiteEtica()
    {
        return View("~/Views/Home/DocenciaInvestigacion/ComiteEtica/ComiteEtica.cshtml");
    }
    #endregion
}