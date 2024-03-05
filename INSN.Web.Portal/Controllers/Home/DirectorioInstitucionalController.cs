using INSN.Utilitarios;
using INSN.Web.Common;
using INSN.Web.Models.Request.Home.DocumentoLegal;
using INSN.Web.Portal.Services.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.ViewModels.Home.DocumentoLegal;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Directorio Institucional
/// </summary>
public class DirectorioInstitucionalController : Controller
{
    private readonly IDocumentoLegalProxy _proxy;

    /// <summary>
    /// Directorio Institucional Controller
    /// </summary>
    /// <param name="proxy"></param>
    /// <param name="TipoDocumentoProxy"></param>
    public DirectorioInstitucionalController(IDocumentoLegalProxy proxy, ITipoDocumentoProxy TipoDocumentoProxy)
    {
        _proxy = proxy;
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View("~/Views/Home/DirectorioInstitucional/Index.cshtml");
    }

    /// <summary>
    /// Documento Legal Listar
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<IActionResult> DocumentoLegal(DocumentoLegalViewModel model)
    {
        var resultDocumentoLegales = await _proxy.DocumentoLegalListar(new DocumentoLegalDtoRequest()
        {
            Documento = model.Documento,
            Descripcion = model.Descripcion,
            CodigoTipoDocumentoId = model.TipoDocumentoSeleccionada,
            Area = model.AreaSeleccionada,
            Estado = Enumerado.Estado.Activo,
            EstadoRegistro = Enumerado.EstadoRegistro.Activo
        });

        model.DocumentoLegales = resultDocumentoLegales;
        model.TituloPagina = model.TituloPagina;

        return View("~/Views/Home/DirectorioInstitucional/DocumentoLegal.cshtml", model);
    }

    #region [Adaptador]
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