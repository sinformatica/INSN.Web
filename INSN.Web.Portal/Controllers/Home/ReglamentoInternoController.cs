using INSN.Web.ViewModels.Home.DocumentoLegal;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Reglamento Interno 
/// </summary>
public class ReglamentoInternoController : Controller
{
    /// <summary>
    /// Reglamento Interno Controller
    /// </summary>
    public ReglamentoInternoController()
    {
    }

    /// <summary>
    /// Documento Legal RI
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public Task<IActionResult> DocumentoLegalRI(DocumentoLegalViewModel model)
    {
        return Task.FromResult<IActionResult>(View("~/Views/Home/ReglamentoInterno/Index.cshtml", model));
    }
}