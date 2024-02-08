using INSN.Web.Common;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home.OportunidadLaboral;
using INSN.Web.Portal.Services.Interfaces.Home.OportunidadLaboral;
using INSN.Web.ViewModels.Home.OportunidadLaboral;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Oportunidad Laboral
/// </summary>
public class OportunidadLaboralController : Controller
{
    private readonly IDocumentoConvocatoriaProxy _proxy;

    /// <summary>
    /// Oportunidad Laboral Controller
    /// </summary>
    /// <param name="proxy"></param>
    public OportunidadLaboralController(IDocumentoConvocatoriaProxy proxy)
    {
        _proxy = proxy;
    }

    /// <summary>
    /// Cargar Página Index
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public IActionResult Index(DocumentoConvocatoriaViewModel model)
    {
        var resultDocumentoConvocatoria = DocumentoConvocatoriaListar();
        resultDocumentoConvocatoria.Wait();

        model.DocumentoConvocatorias = resultDocumentoConvocatoria.Result;

        // Ordenar y agrupar los documentos por codigoConvocatoriaId y codigoTipoDocumentoConvocatoriaId
        var documentosAgrupados = model.DocumentoConvocatorias
     .OrderBy(doc => doc.CodigoConvocatoriaId)
     .ThenBy(doc => doc.CodigoTipoDocumentoConvocatoriaId)
     .GroupBy(doc => new { doc.CodigoConvocatoriaId, doc.CodigoTipoDocumentoConvocatoriaId })
     .Select(grupo => new GrupoDocumentoConvocatoria
     {
         CodigoConvocatoriaId = grupo.Key.CodigoConvocatoriaId,
         DescripcionConvocatoria = grupo.First().DescripcionConvocatoria,
         FechaInicio = grupo.First().FechaInicio,
         FechaFinal = grupo.First().FechaFinal,
         Detalles = grupo.ToList(),
         CodigoTipoConvocatoriaId = grupo.First().CodigoTipoConvocatoriaId,
         DescripcionTipoConvocatoria = grupo.First().DescripcionTipoConvocatoria,
         Estado = grupo.First().Estado,
     })
     .ToList();

        model.DocumentoConvocatoriasAgrupados = documentosAgrupados;

        return View("~/Views/Home/OportunidadLaboral/Index.cshtml", model);
    }

    /// <summary>
    /// Documento Convocatoria Listar
    /// </summary>
    /// <returns></returns>
    public async Task<List<ConvocatoriaDtoResponse>> DocumentoConvocatoriaListar()
    {
        var resultDocumentoConvocatoria = await _proxy.DocumentoConvocatoriaListar(new ConvocatoriaDtoRequest()
        {
            EstadoRegistro = Enumerado.EstadoRegistro.Activo
        });

        return (List<ConvocatoriaDtoResponse>)resultDocumentoConvocatoria;
    }
}