using INSN.Web.Portal.Services.Interfaces.SegApp;
using INSN.Web.Portal.Services.Interfaces.Mantenimiento.LibroReclamaciones;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.ViewModels.Home.LibroReclamacion;
using INSN.Web.ViewModels.Exceptions;
using INSN.Web.Models.Request.Mantenimiento.LibroReclamaciones;
using INSN.Web.Portal.Resources.Home;

namespace INSN.Web.Portal.Controllers.Home;

public class LibroReclamacionController : Controller
{
    private readonly IWebHostEnvironment _enviroment;
    private readonly ILogger<LibroReclamacionController> _logger;
    private readonly ILibroReclamacionProxy _proxy;
    private readonly ITipoDocumentoIdentidadProxy _proxyTipoDocumentoIdentidad;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="LibroReclamacion"></param>
    /// <param name="TipoDocumentoIdentidad"></param>
    /// <param name="logger"></param>
    /// <param name="env"></param>
    public LibroReclamacionController(ILibroReclamacionProxy LibroReclamacion, ITipoDocumentoIdentidadProxy TipoDocumentoIdentidad, ILogger<LibroReclamacionController> logger, IWebHostEnvironment env)
    {
        _proxy = LibroReclamacion;
        _proxyTipoDocumentoIdentidad = TipoDocumentoIdentidad;
        _logger = logger;
        _enviroment = env;
    }

    /// <summary>
    /// Cargar Página Index
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<IActionResult> Index(LibroReclamacionViewModel model)
    {
        var resultTiposDocumentos = await _proxyTipoDocumentoIdentidad.TipoDocumentoIdentidadListar(new TipoDocumentoIdentidadDtoRequest()
        {         
            Estado = "A",
            EstadoRegistro = 1
        });

        model.TiposDocumentosIdentidad = resultTiposDocumentos;

        return View("~/Views/Home/LibroReclamacion/Index.cshtml", model);
    }

    /// <summary>
    /// Libro Reclamacion Insertar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> LibroReclamacionInsertar(LibroReclamacionViewModel request)
    {
        try
        {
            var resultTiposDocumentos = await _proxyTipoDocumentoIdentidad.TipoDocumentoIdentidadListar(new TipoDocumentoIdentidadDtoRequest()
            {
                Estado = "A",
                EstadoRegistro = 1
            });

            request.TiposDocumentosIdentidad = resultTiposDocumentos;

            await _proxy.LibroReclamacionInsertar(new LibroReclamacionDtoRequest
            {
                TipoPersona = request.TipoPersonaSeleccionada,
                TipoDocumentoIdentidad = request.TipoDocumentoIdentidadSeleccionada,
                DocumentoIdentidad = request.DocumentoIdentidad,
                RUC = request.RUC,
                RazonSocial = request.RazonSocial,
                Nombres = request.Nombres,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                Direccion = request.Direccion,
                CelularTelefono = request.CelularTelefono,
                Email = request.Email,
                Reclamo = request.Reclamo,
                TipoParentesco = request.TipoParentescoSeleccionada,
                TipoDocumentoIdentidadPaciente = request.TipoDocumentoIdentidadPacienteSeleccionada,
                DocumentoIdentidadPaciente = request.DocumentoIdentidadPaciente,
                NombrePaciente = request.NombrePaciente,
                ApellidoPaternoPaciente = request.ApellidoPaternoPaciente,
                ApellidoMaternoPaciente = request.ApellidoMaternoPaciente,
                Autorizacion = request.Autorizacion,
                Estado = "A",
                #region [Base Insert]
                EstadoRegistro = 1,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = Environment.UserName, //Modificar por Usuario de sesion logueada
                TerminalCreacion = Environment.MachineName
                #endregion
            });

            #region[Controles de Codigo/Controller]
            TempData["CodigoMensaje"] = 1;
            TempData["Mensaje"] = "Registro enviado correctamente";
            TempData["Metodo"] = "Index";
            TempData["Controlador"] = "LibroReclamacion";
            #endregion           

            return View("~/Views/Home/LibroReclamacion/Index.cshtml", request);
        }
        catch (ModelException ex)
        {
            ModelState.AddModelError(ex.PropertyName, ex.Message);
            _logger.LogError(ex, "Validacion de registro {Message}", ex.Message);
            return View("~/Views/Home/LibroReclamacion/Index.cshtml", request);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Registro de Farmacia {Message}", ex.Message);
            TempData["CodigoMensaje"] = -1;
            TempData["Mensaje"] = ex.Message;

            return View("~/Views/Home/LibroReclamacion/Index.cshtml", request);
        }
    }
}