using INSN.Web.Common;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home.Convocatorias;
using INSN.Web.Portal.Services.Interfaces.Home.Convocatorias;
using INSN.Web.ViewModels.Home.Convocatorias;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Convocatoria Controller
/// </summary>
public class ConvocatoriaController : Controller
{
    private readonly IConvocatoriaProxy _proxy;

    /// <summary>
    /// Instanciar
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
        // Lista tipos
        var resultTipos = _proxy.ConvocatoriaTipoListar();
        model.ConvocatoriaTipoLista = resultTipos.Result;

        // Lista convocatorias
        var resultConvocatorias = ConvocatoriaListar();
        model.ConvocatoriaLista = resultConvocatorias.Result;

        foreach (var item in model.ConvocatoriaLista)
        {
            // Listar detalle convocatoria
            var resultDetalle = _proxy.ConvocatoriaDetalleListar(item.CodigoConvocatoriaId);
            item.DetalleLista = resultDetalle.Result;
        }

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
            CodigoConvocatoriaTipoId = 0,
            Estado = "",
            EstadoRegistro = Enumerado.EstadoRegistro.Activo
        });

        return (List<ConvocatoriaDtoResponse>)result;
    }
}