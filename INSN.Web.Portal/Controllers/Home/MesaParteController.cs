using INSN.Utilitarios;
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

    #region[Abrir archivo]
    /// <summary>
    /// Adaptador Abrir Archivo
    /// </summary>
    /// <param name="RutaArchivo"></param>
    /// <returns></returns>
    public IActionResult AdaptadorAbrirArchivo(string RutaArchivo)
    {
        try
        {
            // Biblioteca Utilitarios
            var (contenidoArchivo, tipoContenido) = GestorArchivo.ObtenerContenidoArchivo(RutaArchivo);

            return File(contenidoArchivo, tipoContenido);
        }
        catch (ArgumentException)
        {
            return View("~/Views/Shared/Error.cshtml");
        }
        catch (FileNotFoundException)
        {
            return View("~/Views/Shared/NotFound.cshtml");
        }
        catch (Exception)
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
    #endregion
}