using INSN.Web.Common;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home.Convocatorias;
using INSN.Web.Portal.Services.Interfaces.Home.Convocatorias;
using INSN.Web.ViewModels.Home.Convocatorias;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Oportunidad Laboral
/// </summary>
public class ConvocatoriaController : Controller
{
    private readonly IConvocatoriaProxy _proxy;

    /// <summary>
    /// Oportunidad Laboral Controller
    /// </summary>
    /// <param name="proxy"></param>
    public ConvocatoriaController(IConvocatoriaProxy proxy)
    {
        _proxy = proxy;
    }

    /// <summary>
    /// Cargar Página Index
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public IActionResult Index(ConvocatoriaViewModel model)
    {
        var resultConvocatorias = ConvocatoriaListar();
        model.ConvocatoriaLista = resultConvocatorias.Result;

        foreach (var item in model.ConvocatoriaLista)
        {
            // Listar detalle convocatoria
            var resultDetalle = _proxy.ConvocatoriaDetalleListar(item.CodigoConvocatoriaId);
            item.DetalleLista = resultDetalle.Result;

            //foreach (var det in item.DetalleLista)
            //{
            //    if (det.RutaImagen != null)
            //    {
            //        // Obtener la extensión
            //        string? extension = Path.GetExtension(det.RutaImagen);
            //        if (extension != null)
            //        {
            //            det.Extension = extension.TrimStart('.').ToLower();

            //            // Leer la imagen y convertirla en un arreglo de bytes
            //            det.ImagenBytes = System.IO.File.ReadAllBytes(det.RutaImagen);
            //        }
            //    }
            //}
        }


        //   var resultDocumentoConvocatoria = DocumentoConvocatoriaListar();
        //   resultDocumentoConvocatoria.Wait();

        //   model.DocumentoConvocatorias = resultDocumentoConvocatoria.Result;

        //   // Ordenar y agrupar los documentos por codigoConvocatoriaId y codigoTipoDocumentoConvocatoriaId
        //   var documentosAgrupados = model.DocumentoConvocatorias
        //.OrderBy(doc => doc.CodigoConvocatoriaId)
        //.ThenBy(doc => doc.CodigoTipoDocumentoConvocatoriaId)
        //.GroupBy(doc => new { doc.CodigoConvocatoriaId, doc.CodigoTipoDocumentoConvocatoriaId })
        //.Select(grupo => new GrupoDocumentoConvocatoria
        //{
        //    CodigoConvocatoriaId = grupo.Key.CodigoConvocatoriaId,
        //    DescripcionConvocatoria = grupo.First().DescripcionConvocatoria,
        //    FechaInicio = grupo.First().FechaInicio,
        //    FechaFinal = grupo.First().FechaFinal,
        //    Detalles = grupo.ToList(),
        //    CodigoTipoConvocatoriaId = grupo.First().CodigoTipoConvocatoriaId,
        //    DescripcionTipoConvocatoria = grupo.First().DescripcionTipoConvocatoria,
        //    Estado = grupo.First().Estado,
        //})
        //.ToList();

        //   model.DocumentoConvocatoriasAgrupados = documentosAgrupados;

        return View("~/Views/Home/Convocatorias/Index.cshtml", model);
    }

    /// <summary>
    /// Convocatoria Listar
    /// </summary>  
    /// <returns></returns>
    public async Task<List<ConvocatoriaDtoResponse>> ConvocatoriaListar()
    {
        var result = await _proxy.ConvocatoriaListar(new ConvocatoriaDtoRequest()
        {
            Descripcion = "",
            Estado = "",
            EstadoRegistro = Enumerado.EstadoRegistro.Activo
        });

        return (List<ConvocatoriaDtoResponse>)result;
    }

    /// <summary>
    /// Documento Convocatoria Listar
    /// </summary>
    /// <returns></returns>
    //public async Task<List<ConvocatoriaDtoResponse>> DocumentoConvocatoriaListar()
    //{
    //    var resultDocumentoConvocatoria = await _proxy.DocumentoConvocatoriaListar(new ConvocatoriaDtoRequest()
    //    {
    //        EstadoRegistro = Enumerado.EstadoRegistro.Activo
    //    });

    //    return (List<ConvocatoriaDtoResponse>)resultDocumentoConvocatoria;
    //}
}