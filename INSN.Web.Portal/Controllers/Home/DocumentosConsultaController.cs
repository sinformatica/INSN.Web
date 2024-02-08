using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Documentos Consulta
/// </summary>
public class DocumentosConsultaController : Controller
{
    /// <summary>
    /// Documentos Consulta Controller
    /// </summary>
    public DocumentosConsultaController()
    {
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View("~/Views/Home/DocumentosConsulta/Index.cshtml");
    }
}