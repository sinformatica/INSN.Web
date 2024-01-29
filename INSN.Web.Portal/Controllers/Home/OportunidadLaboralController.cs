using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Mantenimiento.OportunidadLaboral;
using INSN.Web.Portal.Services.Interfaces.Mantenimiento.OportunidadLaboral;
using INSN.Web.ViewModels.Home.OportunidadLaboral;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

public class OportunidadLaboralController : Controller
{
    private readonly IWebHostEnvironment _enviroment;
    private readonly IDocumentoConvocatoriaProxy _proxy;
    private readonly ILogger<OportunidadLaboralController> _logger;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="proxy"></param>
    /// <param name="logger"></param>
    public OportunidadLaboralController(IDocumentoConvocatoriaProxy proxy, ILogger<OportunidadLaboralController> logger, IWebHostEnvironment env)
    {
        _proxy = proxy;
        _logger = logger;
        _enviroment = env;
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
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<List<DocumentoConvocatoriaDtoResponse>> DocumentoConvocatoriaListar()
    {
        var resultDocumentoConvocatoria = await _proxy.DocumentoConvocatoriaListar(new ConvocatoriaDtoRequest()
        {     
            EstadoRegistro = 1
        });

        return (List<DocumentoConvocatoriaDtoResponse>)resultDocumentoConvocatoria;
    }
}