using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento;
using INSN.Web.ViewModels.Exceptions;
using INSN.Web.ViewModels.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.SegApp.Mantenimiento
{
    public class RolController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly IRolProxy _proxy;
        private readonly ILogger<RolController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public RolController(IRolProxy proxy, 
                        ILogger<RolController> logger, 
                        IWebHostEnvironment env)
        {
            _proxy = proxy;
            _logger = logger;
            _enviroment = env;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Index(RolViewModel model)
        {
            var result = RolListar(model);
            result.Wait();

            return View("~/Views/SegApp/Mantenimiento/Rol/Index.cshtml", model);
        }

        /// <summary>
        /// Retornar al Index sin cargar model
        /// </summary>
        /// <returns></returns>
        public IActionResult Regresar()
        {
            return RedirectToAction("Index", "Rol");
        }

        /// <summary>
        /// Rol Listar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> RolListar(RolViewModel model)
        {
            var response = await _proxy.RolListar(new RolDtoRequest()
            {
                Name = model.Name,
                Estado = model.EstadoSeleccionado
            });

            model.Roles = response;
            return View("~/Views/SegApp/Mantenimiento/Rol/Index.cshtml", model);
        }

        #region [Nuevo]
        /// <summary>
        /// Vista Ventana Nuevo
        /// </summary>
        /// <returns></returns>
        public IActionResult NuevoVista()
        {
            var model = new RolViewModel();

            return View("~/Views/SegApp/Mantenimiento/Rol/Nuevo.cshtml", model);
        }

        /// <summary>
        /// Rol Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RolInsertar(RolViewModel request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    throw new ModelException(nameof(request.Name), "Campo requerido: Nombre");
                }

                await _proxy.RolInsertar(new RolDtoRequest
                {
                    Name = request.Name,
                    Estado = request.EstadoSeleccionado,
                    #region [Base Insert]
                    EstadoRegistro = 1,
                    FechaCreacion = DateTime.Now,
                    UsuarioCreacion = Environment.UserName, //Modificar por Usuario de sesion logueada
                    TerminalCreacion = Environment.MachineName
                    #endregion
                });

                #region[Controles de Codigo/Controller]
                TempData["CodigoMensaje"] = 1;
                TempData["Mensaje"] = "Registro creado correctamente";
                TempData["Metodo"] = "Regresar";
                TempData["Controlador"] = "Rol";
                #endregion

                return View("~/Views/SegApp/Mantenimiento/Rol/Nuevo.cshtml", request);
            }
            catch (ModelException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                _logger.LogError(ex, "Validacion de registro {Message}", ex.Message);
                return View("~/Views/SegApp/Mantenimiento/Rol/Nuevo.cshtml", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registro de Rol {Message}", ex.Message);
                TempData["CodigoMensaje"] = -1;
                TempData["Mensaje"] = ex.Message;

                return View("~/Views/SegApp/Mantenimiento/Rol/Nuevo.cshtml", request);
            }
        }
        #endregion

        #region [Editar]
        /// <summary>
        /// Vista Ventana Editar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> EditarVista(string Id)
        {
            var response = await _proxy.RolBuscarId(Id);
            if (response is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new RolViewModel
            {
                Name = response.Name,
                Id = response. Id
            };

            return View("~/Views/SegApp/Mantenimiento/Rol/Editar.cshtml", model);
        }

        /// <summary>
        /// Rol Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IActionResult> RolActualizar(RolViewModel request)
        {
            var response = await _proxy.RolBuscarId(request.Id);

            if (response is null)
            {
                ModelState.AddModelError("ID", "No se encontro el registro");
                return View();
            }

            try
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    throw new ModelException(nameof(request.Name), "Campo requerido: Descripción");
                }

                var dtoRequest = new RolDtoRequest
                {
                    Id = request.Id,
                    Name = request.Name,
                    Estado = request.EstadoSeleccionado,
                    #region [Base Update]
                    EstadoRegistro = 1,
                    FechaCreacion = response.FechaCreacion,
                    UsuarioCreacion = response.UsuarioCreacion,
                    TerminalCreacion = response.TerminalCreacion,
                    TerminalModificacion = Environment.MachineName,
                    UsuarioModificacion = Environment.UserName, //Modificar por Usuario de sesion logueada
                    FechaModificacion = DateTime.Now
                    #endregion
                };

                await _proxy.RolActualizar(dtoRequest);

                #region[Controles de Codigo/Controller]
                TempData["CodigoMensaje"] = 1;
                TempData["Mensaje"] = "Registro actualizado correctamente";
                TempData["Metodo"] = "Regresar";
                TempData["Controlador"] = "Rol";
                #endregion

                return View("~/Views/SegApp/Mantenimiento/Rol/Editar.cshtml", request);

            }
            catch (ModelException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                _logger.LogError(ex, "Validación de registro {Message}", ex.Message);
                return View("~/Views/SegApp/Mantenimiento/Rol/Editar.cshtml", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Modificación de Rol {Message}", ex.Message);

                TempData["CodigoMensaje"] = -1;
                TempData["Mensaje"] = ex.Message;

                return View("~/Views/SegApp/Mantenimiento/Rol/Editar.cshtml", request);
            }
        }
        #endregion

        /// <summary>
        /// Rol Eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RedirectToActionResult> RolEliminar(string id)
        {
            await _proxy.RolEliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}