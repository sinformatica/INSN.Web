using INSN.Utilitarios;
using INSN.Web.Common;
using INSN.Web.Models.Request.Home.DocumentoLegal;
using INSN.Web.Models.Response.Home.DocumentoLegal;
using INSN.Web.Portal.Services.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.ViewModels.Home.DocumentoLegal;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador  POA
/// </summary>
public class POAController : Controller
{
    private readonly IDocumentoLegalProxy _proxy;
    private readonly ITipoDocumentoProxy _TipoDocumentoProxy;

    /// <summary>
    /// POA Controller
    /// </summary>
    /// <param name="proxy"></param>
    /// <param name="TipoDocumentoProxy"></param>
    public POAController(IDocumentoLegalProxy proxy, ITipoDocumentoProxy TipoDocumentoProxy)
    {
        _proxy = proxy;
        _TipoDocumentoProxy = TipoDocumentoProxy;
    }

    /// <summary>
    /// Cargar Página Index
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<IActionResult> Index(DocumentoLegalViewModel model)
    {
        var resultTipoDocumento = await _TipoDocumentoProxy.TipoDocumentoListar(new TipoDocumentoDtoRequest()
        {
            Area = Enumerado.DocumentoLegal.PROA,
            Estado = Enumerado.Estado.Activo,
            EstadoRegistro = Enumerado.EstadoRegistro.Activo
        });

        var resultDocumentoLegal = DocumentoLegalListar(model);
        resultDocumentoLegal.Wait();

        model.TipoDocumentos = resultTipoDocumento;
        model.DocumentoLegales = resultDocumentoLegal.Result;

        return View("~/Views/Home/POA/Index.cshtml", model);
    }

    /// <summary>
    /// Documento Legal Listar
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<List<DocumentoLegalDtoResponse>> DocumentoLegalListar(DocumentoLegalViewModel model)
    {
        var resultDocumentoLegales = await _proxy.DocumentoLegalListar(new DocumentoLegalDtoRequest()
        {
            Documento = model.Documento,
            Descripcion = model.Descripcion,
            CodigoTipoDocumentoId = model.TipoDocumentoSeleccionada,
            Area = Enumerado.DocumentoLegal.PROA,
            Estado = Enumerado.Estado.Activo,
            EstadoRegistro = Enumerado.EstadoRegistro.Activo
        });

        return (List<DocumentoLegalDtoResponse>)resultDocumentoLegales;
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