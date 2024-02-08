using INSN.Web.Common;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response.Sistemas;
using INSN.Web.Portal.Services.Interfaces.SegApp;
using INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento;
using INSN.Web.ViewModels.Exceptions;
using INSN.Web.ViewModels.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace INSN.Web.Portal.Controllers.SegApp.Usuario
{
    /// <summary>
    /// UsuarioController
    /// </summary>
    public class UsuarioController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioProxy _proxy;
        private readonly ITipoDocumentoIdentidadProxy _proxyTipoDoc;
        private readonly ISistemaProxy _proxySistema;
        private readonly IRolProxy _proxyRol;
        private readonly IUsuarioRolProxy _proxyUsuarioRol;
        private readonly IHttpContextAccessor? _httpContextAccessor;
        private readonly string? CodigoSistemaIdUsuario;
        private readonly string? NombreRolUsuario;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        /// <param name="proxyTipoDoc"></param>
        /// <param name="proxySistema"></param>
        /// <param name="proxyRol"></param>
        /// <param name="proxyUsuarioRol"></param>
        /// <param name="httpContextAccessor"></param>
        public UsuarioController(IUsuarioProxy proxy,
                                ILogger<UsuarioController> logger,
                                IWebHostEnvironment env,
                                ITipoDocumentoIdentidadProxy proxyTipoDoc,
                                ISistemaProxy proxySistema,
                                IRolProxy proxyRol,
                                IUsuarioRolProxy proxyUsuarioRol,
                                IHttpContextAccessor httpContextAccessor)
        {
            _proxy = proxy;
            _logger = logger;
            _enviroment = env;
            _proxyTipoDoc = proxyTipoDoc;
            _proxySistema = proxySistema;
            _proxyRol = proxyRol;
            _proxyUsuarioRol = proxyUsuarioRol;
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

            CodigoSistemaIdUsuario = _httpContextAccessor?.HttpContext?.Session.GetString(Constantes.CodigoSistemaIdUsuario);
            NombreRolUsuario = _httpContextAccessor?.HttpContext?.Session.GetString(Constantes.NombreRolUsuario);
        }

        /// <summary>
        /// Validar Sistema
        /// </summary>
        /// <returns></returns>
        private bool ValidarSistema()
        {
            return CodigoSistemaIdUsuario == Constantes.CodigoSistemaIdFijo;
        }

        /// <summary>
        /// Cargar Página Index
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Index(UsuarioViewModel model)
        {
            bool b = false;

            if (ValidarSistema())
            {
                if (NombreRolUsuario == Constantes.RolAdminSistemas) b = true;
            }

            if (b)
            {
                var result = UsuarioListar(model);
                result.Wait();
                model.Usuarios = result.Result;

                return View("~/Views/SegApp/Mantenimiento/Usuario/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("AccesoDenegado", "Acceso");
            }
        }

        /// <summary>
        /// Usuario Listar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<List<UsuarioDtoResponse>> UsuarioListar(UsuarioViewModel model)
        {
            var result = await _proxy.UsuarioListar(new UsuarioDtoRequest()
            {
                Estado = model.EstadoSeleccionado,
                Nombres = model.TextoBuscar,
                EstadoRegistro = Enumerado.EstadoRegistro.Activo
            });

            return (List<UsuarioDtoResponse>)result;
        }

        /// <summary>
        /// Retornar al Index sin cargar Modal
        /// </summary>
        /// <returns></returns>
        public IActionResult Regresar()
        {
            return RedirectToAction("Index", "Usuario");
        }

        /// <summary>
        /// Tipo Documento Identidad Listar 
        /// </summary>
        /// <returns></returns>
        public async Task<List<TipoDocumentoIdentidadDtoResponse>> TipoDocumentoIdentidadListar()
        {
            var result = await _proxyTipoDoc.TipoDocumentoIdentidadListar(new TipoDocumentoIdentidadDtoRequest()
            {
            });

            return (List<TipoDocumentoIdentidadDtoResponse>)result;
        }

        #region [Nuevo]
        /// <summary>
        /// Vista Ventana Nuevo
        /// </summary>
        /// <returns></returns>
        public Task<IActionResult> NuevoVista(UsuarioViewModel model)
        {
            bool b = false;

            if (ValidarSistema())
            {
                if (NombreRolUsuario == Constantes.RolAdminSistemas) b = true;
            }

            if (b)
            {
                var resultTiposDoc = TipoDocumentoIdentidadListar();
                model.TiposDocIdentidad = resultTiposDoc.Result;

                return Task.FromResult<IActionResult>(View("~/Views/SegApp/Mantenimiento/Usuario/Nuevo.cshtml", model));
            }
            else
            {
                return Task.FromResult<IActionResult>(RedirectToAction("AccesoDenegado", "Acceso"));
            }
        }

        /// <summary>
        /// Usuario Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UsuarioInsertar(UsuarioViewModel request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Nombres)) throw new ModelException(nameof(request.Nombres), "Campo requerido: Nombre");
                if (string.IsNullOrWhiteSpace(request.ApellidoPaterno)) throw new ModelException(nameof(request.ApellidoPaterno), "Campo requerido: Apellido paterno");
                if (string.IsNullOrWhiteSpace(request.ApellidoMaterno)) throw new ModelException(nameof(request.ApellidoMaterno), "Campo requerido: Apellido materno");
                if (string.IsNullOrWhiteSpace(request.Servicio)) throw new ModelException(nameof(request.Servicio), "Campo requerido: Servicio");
                if (string.IsNullOrWhiteSpace(request.DocumentoIdentidad)) throw new ModelException(nameof(request.DocumentoIdentidad), "Campo requerido: Documento identidad");
                if (string.IsNullOrWhiteSpace(request.Correo)) throw new ModelException(nameof(request.Correo), "Campo requerido: Correo");
                if (string.IsNullOrWhiteSpace(request.Telefono1)) throw new ModelException(nameof(request.Telefono1), "Campo requerido: Teléfono 1");
                if (string.IsNullOrWhiteSpace(request.Clave)) throw new ModelException(nameof(request.Clave), "Campo requerido: Contraseña");

                if (string.IsNullOrWhiteSpace(request.ConfirmaClave))
                {
                    throw new ModelException(nameof(request.ConfirmaClave), "Campo requerido: Confirmar contraseña");
                }
                else
                {
                    if (request.Clave != request.ConfirmaClave) throw new ModelException(nameof(request.ConfirmaClave), "Contraseñas no coinciden");
                }

                // Validar usuario
                string usuario = await _proxy.UsuarioValidar(new UsuarioDtoRequest
                {
                    Nombres = request.Nombres,
                    ApellidoPaterno = request.ApellidoPaterno,
                    ApellidoMaterno = request.ApellidoMaterno
                });
                request.Usuario = usuario;

                await _proxy.UsuarioInsertar(new UsuarioDtoRequest
                {
                    Nombres = request.Nombres,
                    ApellidoPaterno = request.ApellidoPaterno,
                    ApellidoMaterno = request.ApellidoMaterno,
                    Servicio = request.Servicio,
                    TipoDocumentoIdentidadId = request.TipoDocumentoIdentidadId,
                    DocumentoIdentidad = request.DocumentoIdentidad,
                    UserName = request.Usuario,
                    Email = request.Correo,
                    PhoneNumber = request.Telefono1,
                    Telefono2 = request.Telefono2,
                    Password = request.Clave,
                    ConfirmarPassword = request.ConfirmaClave,
                    Estado = request.EstadoSeleccionado,
                    #region [Base Insert]
                    EstadoRegistro = Enumerado.EstadoRegistro.Activo,
                    FechaCreacion = DateTime.Now,
                    UsuarioCreacion = Environment.UserName, //Modificar por Usuario de sesion logueada
                    TerminalCreacion = Environment.MachineName
                    #endregion
                });

                #region[Controles de Codigo/Controller]
                TempData["CodigoMensaje"] = 1;
                TempData["Mensaje"] = "Usuario " + request.Usuario + " creado correctamente";
                TempData["Metodo"] = "Regresar";
                TempData["Controlador"] = "Usuario";
                #endregion

                var resultTiposDoc = TipoDocumentoIdentidadListar();
                request.TiposDocIdentidad = resultTiposDoc.Result;
                return View("~/Views/SegApp/Mantenimiento/Usuario/Nuevo.cshtml", request);
            }
            catch (ModelException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                _logger.LogError(ex, "Validacion de registro {Message}", ex.Message);

                var resultTiposDoc = TipoDocumentoIdentidadListar();
                request.TiposDocIdentidad = resultTiposDoc.Result;
                return View("~/Views/SegApp/Mantenimiento/Usuario/Nuevo.cshtml", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registro de Usuario {Message}", ex.Message);
                TempData["CodigoMensaje"] = -1;
                TempData["Mensaje"] = ex.Message;

                var resultTiposDoc = TipoDocumentoIdentidadListar();
                request.TiposDocIdentidad = resultTiposDoc.Result;
                return View("~/Views/SegApp/Mantenimiento/Usuario/Nuevo.cshtml", request);
            }
        }
        #endregion

        #region [Editar]
        /// <summary>
        /// Ventana Editar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> EditarVista(string Id)
        {
            bool b = false;

            if (ValidarSistema())
            {
                if (NombreRolUsuario == Constantes.RolAdminSistemas) b = true;
            }

            if (b)
            {
                var response = await _proxy.UsuarioBuscarId(Id);
                if (response is null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var model = new UsuarioViewModel
                {
                    Id = response.Id ?? string.Empty,
                    Nombres = response.Nombres,
                    ApellidoPaterno = response.ApellidoPaterno,
                    ApellidoMaterno = response.ApellidoMaterno,
                    Servicio = response.Servicio,
                    TipoDocumentoIdentidadId = response.TipoDocumentoIdentidadId,
                    DocumentoIdentidad = response.DocumentoIdentidad,
                    Correo = response.Email,
                    Telefono1 = response.PhoneNumber,
                    Telefono2 = response.Telefono2,
                    Usuario = response.UserName,
                    EstadoSeleccionado = response.Estado
                };

                var resultTiposDoc = TipoDocumentoIdentidadListar();
                model.TiposDocIdentidad = resultTiposDoc.Result;

                return View("~/Views/SegApp/Mantenimiento/Usuario/Editar.cshtml", model);
            }
            else
            {
                return RedirectToAction("AccesoDenegado", "Acceso");
            }
        }

        /// <summary>
        /// Usuario Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IActionResult> UsuarioActualizar(UsuarioViewModel request)
        {
            try
            {
                var response = await _proxy.UsuarioBuscarId(request.Id);

                if (response is null)
                {
                    ModelState.AddModelError("ID", "No se encontro el registro");
                    return View();
                }

                var resultTiposDoc = TipoDocumentoIdentidadListar();
                request.TiposDocIdentidad = resultTiposDoc.Result;

                if (string.IsNullOrWhiteSpace(request.Nombres)) throw new ModelException(nameof(request.Nombres), "Campo requerido: Nombre");
                if (string.IsNullOrWhiteSpace(request.ApellidoPaterno)) throw new ModelException(nameof(request.ApellidoPaterno), "Campo requerido: Apellido paterno");
                if (string.IsNullOrWhiteSpace(request.ApellidoMaterno)) throw new ModelException(nameof(request.ApellidoMaterno), "Campo requerido: Apellido materno");
                if (string.IsNullOrWhiteSpace(request.Servicio)) throw new ModelException(nameof(request.Servicio), "Campo requerido: Servicio");
                if (string.IsNullOrWhiteSpace(request.DocumentoIdentidad)) throw new ModelException(nameof(request.DocumentoIdentidad), "Campo requerido: Documento identidad");
                if (string.IsNullOrWhiteSpace(request.Correo)) throw new ModelException(nameof(request.Correo), "Campo requerido: Correo");
                if (string.IsNullOrWhiteSpace(request.Telefono1)) throw new ModelException(nameof(request.Telefono1), "Campo requerido: Teléfono 1");

                var dtoRequest = new UsuarioDtoRequest
                {
                    Id = request.Id,
                    Nombres = request.Nombres,
                    ApellidoPaterno = request.ApellidoPaterno,
                    ApellidoMaterno = request.ApellidoMaterno,
                    Servicio = request.Servicio,
                    TipoDocumentoIdentidadId = request.TipoDocumentoIdentidadId,
                    DocumentoIdentidad = request.DocumentoIdentidad,
                    UserName = request.Usuario,
                    NormalizedUserName = (request.Usuario ?? string.Empty).ToUpper(),
                    Email = request.Correo,
                    NormalizedEmail = request.Correo.ToUpper(),
                    PhoneNumber = request.Telefono1,
                    Telefono2 = request.Telefono2,
                    Estado = request.EstadoSeleccionado,
                    #region [Base Update]
                    EstadoRegistro = Enumerado.EstadoRegistro.Activo,
                    FechaCreacion = response.FechaCreacion,
                    UsuarioCreacion = response.UsuarioCreacion,
                    TerminalCreacion = response.TerminalCreacion,
                    TerminalModificacion = Environment.MachineName,
                    UsuarioModificacion = Environment.UserName, //Modificar por Usuario de sesion logueada
                    FechaModificacion = DateTime.Now
                    #endregion
                };

                await _proxy.UsuarioActualizar(dtoRequest);

                #region[Controles de Codigo/Controller]
                TempData["CodigoMensaje"] = 1;
                TempData["Mensaje"] = "Registro actualizado correctamente";
                TempData["Metodo"] = "Regresar";
                TempData["Controlador"] = "Usuario";
                #endregion

                return View("~/Views/SegApp/Mantenimiento/Usuario/Editar.cshtml", request);
            }
            catch (ModelException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                _logger.LogError(ex, "Validación de registro {Message}", ex.Message);
                return View("~/Views/SegApp/Mantenimiento/Usuario/Editar.cshtml", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Modificación de Usuario {Message}", ex.Message);
                TempData["CodigoMensaje"] = -1;
                TempData["Mensaje"] = ex.Message;

                var resultTiposDoc = TipoDocumentoIdentidadListar();
                request.TiposDocIdentidad = resultTiposDoc.Result;
                return View("~/Views/SegApp/Mantenimiento/Usuario/Editar.cshtml", request);
            }
        }
        #endregion

        #region [Eliminar]
        /// <summary>
        /// Usuario Eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RedirectToActionResult> UsuarioEliminar(string id)
        {
            await _proxy.UsuarioEliminar(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region [Editar clave]
        /// <summary>
        /// Vista Ventana Editar Clave
        /// </summary>
        /// <returns></returns>
        public Task<IActionResult> EditarClaveVista(UsuarioViewModel model)
        {
            bool b = false;

            if (ValidarSistema())
            {
                if (NombreRolUsuario == Constantes.RolAdminSistemas) b = true;
            }

            if (b)
            {
                var resultTiposDoc = TipoDocumentoIdentidadListar();
                model.TiposDocIdentidad = resultTiposDoc.Result;

                return Task.FromResult<IActionResult>(View("~/Views/SegApp/Mantenimiento/Usuario/EditarClave.cshtml", model));
            }
            else
            {
                return Task.FromResult<IActionResult>(RedirectToAction("AccesoDenegado", "Acceso"));
            }
        }

        /// <summary>
        /// Usuario Actualizar Clave
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IActionResult> UsuarioActualizarClave(UsuarioViewModel request)
        {
            try
            {
                var resultTiposDoc = TipoDocumentoIdentidadListar();
                request.TiposDocIdentidad = resultTiposDoc.Result;

                var response = await _proxy.UsuarioBuscarId(request.Id);

                if (response is null)
                {
                    ModelState.AddModelError("ID", "No se encontro el registro");
                    return View();
                }

                if (string.IsNullOrWhiteSpace(request.Clave)) throw new ModelException(nameof(request.Clave), "Campo requerido: Contraseña");

                if (string.IsNullOrWhiteSpace(request.ConfirmaClave))
                {
                    throw new ModelException(nameof(request.ConfirmaClave), "Campo requerido: Confirmar contraseña");
                }
                else
                {
                    if (request.Clave != request.ConfirmaClave) throw new ModelException(nameof(request.ConfirmaClave), "Contraseñas no coinciden");
                }

                var dtoRequest = new UsuarioDtoRequest
                {
                    Id = request.Id,
                    Password = request.Clave,
                    ConfirmarPassword = request.Clave,
                    #region [Base Update]
                    EstadoRegistro = Enumerado.EstadoRegistro.Activo,
                    FechaCreacion = response.FechaCreacion,
                    UsuarioCreacion = response.UsuarioCreacion,
                    TerminalCreacion = response.TerminalCreacion,
                    TerminalModificacion = Environment.MachineName,
                    UsuarioModificacion = Environment.UserName, //Modificar por Usuario de sesion logueada
                    FechaModificacion = DateTime.Now
                    #endregion
                };

                await _proxy.UsuarioActualizarClave(dtoRequest);

                #region[Controles de Codigo/Controller]
                TempData["CodigoMensaje"] = 1;
                TempData["Mensaje"] = "Contraseña actualizada correctamente";
                TempData["Metodo"] = "Regresar";
                TempData["Controlador"] = "Usuario";
                #endregion

                return View("~/Views/SegApp/Mantenimiento/Usuario/EditarClave.cshtml", request);
            }
            catch (ModelException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                _logger.LogError(ex, "Validación de registro {Message}", ex.Message);
                return View("~/Views/SegApp/Mantenimiento/Usuario/EditarClave.cshtml", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Modificación de Usuario {Message}", ex.Message);
                TempData["CodigoMensaje"] = -1;
                TempData["Mensaje"] = ex.Message;
                return View("~/Views/SegApp/Mantenimiento/Usuario/EditarClave.cshtml", request);
            }
        }
        #endregion

        #region [Editar roles]
        /// <summary>
        /// Vista Ventana Editar Roles
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EditarRolesVista(UsuarioViewModel model)
        {
            bool b = false;

            if (ValidarSistema())
            {
                if (NombreRolUsuario == Constantes.RolAdminSistemas) b = true;
            }

            if (b)
            {
                model.Sistemas = await SistemaListar();
                model.Roles = await RolPorSistemaListar();
                model.UsuarioRoles = await UsuarioRolListar(model.Id);

                return View("~/Views/SegApp/Mantenimiento/Usuario/EditarRoles.cshtml", model);
            }
            else
            {
                return RedirectToAction("AccesoDenegado", "Acceso");
            }
        }

        /// <summary>
        /// Sistema Listar 
        /// </summary>
        /// <returns></returns>
        public async Task<List<SistemaDtoResponse>> SistemaListar()
        {
            var result = await _proxySistema.SistemaListar();
            return (List<SistemaDtoResponse>)result;
        }

        /// <summary>
        /// Rol Por Sistema Listar
        /// </summary>
        /// <returns></returns>
        public async Task<List<RolDtoResponse>> RolPorSistemaListar()
        {
            var result = await _proxyRol.RolPorSistemaListar(0);

            if (result != null)
            {
                return (List<RolDtoResponse>)result;
            }
            else
            {
                // Manejar el caso en el que no se pueden obtener datos válidos
                // Puede ser lanzando una excepción o devolviendo una lista vacía según sea necesario
                return new List<RolDtoResponse>();
            }
        }

        /// <summary>
        /// Usuario Rol Listar
        /// </summary>
        /// <returns></returns>
        public async Task<List<UsuarioRolDtoResponse>> UsuarioRolListar(string? UserId)
        {
            var result = await _proxyUsuarioRol.UsuarioRolListar(UserId);
            return (List<UsuarioRolDtoResponse>)result;
        }

        /// <summary>
        /// Usuario Rol Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UsuarioRolInsertar(UsuarioViewModel request)
        {
            try
            {
                request.Sistemas = await SistemaListar();
                request.Roles = await RolPorSistemaListar();
                request.UsuarioRoles = await UsuarioRolListar(request.Id);

                await _proxyUsuarioRol.UsuarioRolInsertar(new UsuarioRolDtoRequest
                {
                    UserId = request.Id,
                    RolId = request.RolSeleccionado,
                    CodigoSistemaId = request.SistemaSeleccionado,
                    Estado = "A",
                    #region [Base Insert]
                    EstadoRegistro = Enumerado.EstadoRegistro.Activo,
                    FechaCreacion = DateTime.Now,
                    UsuarioCreacion = Environment.UserName, //Modificar por Usuario de sesion logueada
                    TerminalCreacion = Environment.MachineName
                    #endregion
                });

                #region[Controles de Codigo/Controller]
                TempData["CodigoMensaje"] = 1;
                TempData["Mensaje"] = "Rol agregado correctamente";
                TempData["Metodo"] = "EditarRolesVista";
                TempData["Controlador"] = "Usuario";
                TempData["CodigoId"] = request.Id;
                #endregion

                request.Sistemas = await SistemaListar();
                request.Roles = await RolPorSistemaListar();
                request.UsuarioRoles = await UsuarioRolListar(request.Id);


                return View("~/Views/SegApp/Mantenimiento/Usuario/EditarRoles.cshtml", request);
            }
            catch (ModelException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                _logger.LogError(ex, "Validacion de registro {Message}", ex.Message);

                return View("~/Views/SegApp/Mantenimiento/Usuario/EditarRoles.cshtml", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registro de Usuario {Message}", ex.Message);
                TempData["CodigoMensaje"] = -1;
                TempData["Mensaje"] = ex.Message;

                return View("~/Views/SegApp/Mantenimiento/Usuario/EditarRoles.cshtml", request);
            }
        }
        #endregion

        #region [Eliminar Rol Usuario]
        /// <summary>
        /// Usuario Rol Eliminar
        /// </summary>
        /// <param name="CodigoUsuarioRolId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IActionResult> UsuarioRolEliminar(int CodigoUsuarioRolId, string UserId)
        {
            await _proxyUsuarioRol.UsuarioRolEliminar(CodigoUsuarioRolId);

            var model = new UsuarioViewModel
            {
                Sistemas = await SistemaListar(),
                Roles = await RolPorSistemaListar(),
                UsuarioRoles = await UsuarioRolListar(UserId),
                Id = UserId
            };

            return View("~/Views/SegApp/Mantenimiento/Usuario/EditarRoles.cshtml", model);
        }
        #endregion
    }
}