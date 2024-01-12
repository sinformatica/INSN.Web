﻿using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response.Sistemas;
using INSN.Web.Portal.Services.Interfaces.SegApp;
using INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento;
using INSN.Web.ViewModels;
using INSN.Web.ViewModels.Exceptions;
using INSN.Web.ViewModels.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace INSN.Web.Portal.Controllers.SegApp.Usuario
{
    public class UsuarioController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioProxy _proxy;
        private readonly ITipoDocumentoIdentidadProxy _proxyTipoDoc;
        private readonly ISistemaProxy _proxySistema;
        private readonly IRolProxy _proxyRol;
        private readonly IUsuarioRolProxy _proxyUsuarioRol;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public UsuarioController(IUsuarioProxy proxy,
                                ILogger<UsuarioController> logger,
                                IWebHostEnvironment env, 
                                ITipoDocumentoIdentidadProxy proxyTipoDoc,
                                ISistemaProxy proxySistema,
                                IRolProxy proxyRol,
                                IUsuarioRolProxy proxyUsuarioRol)
        {
            _proxy = proxy;
            _logger = logger;
            _enviroment = env;
            _proxyTipoDoc = proxyTipoDoc;
            _proxySistema = proxySistema;
            _proxyRol = proxyRol;
            _proxyUsuarioRol = proxyUsuarioRol;
        }

        /// <summary>
        /// Cargar Página Index
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Index(UsuarioViewModel model)
        {
            var result = UsuarioListar(model);
            result.Wait();
            model.Usuarios = result.Result;

            return View("~/Views/SegApp/Mantenimiento/Usuario/Index.cshtml", model);
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
                EstadoRegistro = 1
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
        public async Task<IActionResult> NuevoVista(UsuarioViewModel model)
        {
            var resultTiposDoc = TipoDocumentoIdentidadListar();
            model.TiposDocIdentidad = resultTiposDoc.Result;

            return View("~/Views/SegApp/Mantenimiento/Usuario/Nuevo.cshtml", model);
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
                if (string.IsNullOrWhiteSpace(request.Nombre)) throw new ModelException(nameof(request.Nombre), "Campo requerido: Nombre");
                if (string.IsNullOrWhiteSpace(request.ApellidoPaterno)) throw new ModelException(nameof(request.ApellidoPaterno), "Campo requerido: Apellido paterno");
                if (string.IsNullOrWhiteSpace(request.ApellidoMaterno)) throw new ModelException(nameof(request.ApellidoMaterno), "Campo requerido: Apellido materno");
                if (string.IsNullOrWhiteSpace(request.Servicio)) throw new ModelException(nameof(request.Servicio), "Campo requerido: Servicio");
                if (string.IsNullOrWhiteSpace(request.DocumentoIdentidad)) throw new ModelException(nameof(request.DocumentoIdentidad), "Campo requerido: Documento identidad");
                if (string.IsNullOrWhiteSpace(request.Correo)) throw new ModelException(nameof(request.Correo), "Campo requerido: Correo");
                if (string.IsNullOrWhiteSpace(request.Telefono1)) throw new ModelException(nameof(request.Telefono1), "Campo requerido: Teléfono 1");
                if (string.IsNullOrWhiteSpace(request.Usuario)) throw new ModelException(nameof(request.Usuario), "Campo requerido: Usuario");
                if (string.IsNullOrWhiteSpace(request.Clave)) throw new ModelException(nameof(request.Clave), "Campo requerido: Contraseña");
               
                if (string.IsNullOrWhiteSpace(request.ConfirmaClave))
                {
                    throw new ModelException(nameof(request.ConfirmaClave), "Campo requerido: Confirmar contraseña");
                }
                else
                {
                    if (request.Clave != request.ConfirmaClave) throw new ModelException(nameof(request.ConfirmaClave), "Contraseñas no coinciden");
                }

                await _proxy.UsuarioInsertar(new UsuarioDtoRequest
                {
                    Nombres = request.Nombre,
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
            var response = await _proxy.UsuarioBuscarId(Id);
            if (response is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new UsuarioViewModel
            {
                Id = response.Id,
                Nombre = response.Nombres,
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

                if (string.IsNullOrWhiteSpace(request.Nombre)) throw new ModelException(nameof(request.Nombre), "Campo requerido: Nombre");
                if (string.IsNullOrWhiteSpace(request.ApellidoPaterno)) throw new ModelException(nameof(request.ApellidoPaterno), "Campo requerido: Apellido paterno");
                if (string.IsNullOrWhiteSpace(request.ApellidoMaterno)) throw new ModelException(nameof(request.ApellidoMaterno), "Campo requerido: Apellido materno");
                if (string.IsNullOrWhiteSpace(request.Servicio)) throw new ModelException(nameof(request.Servicio), "Campo requerido: Servicio");
                if (string.IsNullOrWhiteSpace(request.DocumentoIdentidad)) throw new ModelException(nameof(request.DocumentoIdentidad), "Campo requerido: Documento identidad");
                if (string.IsNullOrWhiteSpace(request.Correo)) throw new ModelException(nameof(request.Correo), "Campo requerido: Correo");
                if (string.IsNullOrWhiteSpace(request.Telefono1)) throw new ModelException(nameof(request.Telefono1), "Campo requerido: Teléfono 1");
                if (string.IsNullOrWhiteSpace(request.Usuario)) throw new ModelException(nameof(request.Usuario), "Campo requerido: Usuario");
                
                var dtoRequest = new UsuarioDtoRequest
                {
                    Id = request.Id,
                    Nombres = request.Nombre,
                    ApellidoPaterno = request.ApellidoPaterno,
                    ApellidoMaterno = request.ApellidoMaterno,
                    Servicio = request.Servicio,
                    TipoDocumentoIdentidadId = request.TipoDocumentoIdentidadId,
                    DocumentoIdentidad = request.DocumentoIdentidad,
                    UserName = request.Usuario,
                    NormalizedUserName = request.Usuario.ToUpper(),
                    Email = request.Correo,
                    NormalizedEmail = request.Correo.ToUpper(),
                    PhoneNumber = request.Telefono1,
                    Telefono2 = request.Telefono2,
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
        /// UsuarioEliminar
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
        public async Task<IActionResult> EditarClaveVista(UsuarioViewModel model)
        {
            var resultTiposDoc = TipoDocumentoIdentidadListar();
            model.TiposDocIdentidad = resultTiposDoc.Result;

            return View("~/Views/SegApp/Mantenimiento/Usuario/EditarClave.cshtml", model);
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

                var resultTiposDoc = TipoDocumentoIdentidadListar();
                request.TiposDocIdentidad = resultTiposDoc.Result;

                var dtoRequest = new UsuarioDtoRequest
                {
                    Id = request.Id,
                    Password = request.Clave,
                    ConfirmarPassword = request.Clave,
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

                var resultTiposDoc = TipoDocumentoIdentidadListar();
                request.TiposDocIdentidad = resultTiposDoc.Result;
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
            model.Sistemas = await SistemaListar();
            model.Roles = await RolPorSistemaListar(9);
            model.UsuarioRoles = await UsuarioRolListar(model.Id);

            return View("~/Views/SegApp/Mantenimiento/Usuario/EditarRoles.cshtml", model);
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
        public async Task<List<RolDtoResponse>> RolPorSistemaListar(int CodigoSistemaId)
        {
            var result = await _proxyRol.RolPorSistemaListar(CodigoSistemaId);

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
        /// Sistema Listar 
        /// </summary>
        /// <returns></returns>
        public async Task<List<UsuarioRolDtoResponse>> UsuarioRolListar(string UserId)
        {
            var result = await _proxyUsuarioRol.UsuarioRolListar(UserId);
            return (List<UsuarioRolDtoResponse>)result;
        }

        /// <summary>
        /// Usuario Rol Asignar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UsuarioRolAsignar(UsuarioViewModel request)
        {
            try
            {
                await _proxyUsuarioRol.UsuarioRolAsignar(new UsuarioRolDtoRequest
                {
                    UserId = request.Id,
                    RolId = request.RolSeleccionado,
                    CodigoSistemaId = request.SistemaSeleccionado,
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
                TempData["Mensaje"] = "Rol agregado correctamente";
                TempData["Metodo"] = "EditarRolesVista";
                TempData["Controlador"] = "Usuario";
                TempData["CodigoId"] = request.Id;
                #endregion

                request.Sistemas = await SistemaListar();
                request.Roles = await RolPorSistemaListar(request.SistemaSeleccionado);
                request.UsuarioRoles = await UsuarioRolListar(request.Id);

         
                return View("~/Views/SegApp/Mantenimiento/Usuario/EditarRoles.cshtml", request);
            }
            catch (ModelException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                _logger.LogError(ex, "Validacion de registro {Message}", ex.Message);

                request.Sistemas = await SistemaListar();
                request.Roles = await RolPorSistemaListar(request.SistemaSeleccionado);
                request.UsuarioRoles = await UsuarioRolListar(request.Id);

                return View("~/Views/SegApp/Mantenimiento/Usuario/EditarRoles.cshtml", request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registro de Usuario {Message}", ex.Message);
                TempData["CodigoMensaje"] = -1;
                TempData["Mensaje"] = ex.Message;

                request.Sistemas = await SistemaListar();
                request.Roles = await RolPorSistemaListar(request.SistemaSeleccionado);
                request.UsuarioRoles = await UsuarioRolListar(request.Id);

                return View("~/Views/SegApp/Mantenimiento/Usuario/EditarRoles.cshtml", request);
            }
        }
        #endregion

        /// <summary>
        /// UsuarioRolEliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> UsuarioRolEliminar(int CodigoUsurioRolId, string UserId)
        {
            await _proxyUsuarioRol.UsuarioRolEliminar(CodigoUsurioRolId);

            var model = new UsuarioViewModel
            {
                Sistemas = await SistemaListar(),
                Roles = await RolPorSistemaListar(9),
                UsuarioRoles = await UsuarioRolListar(UserId),
                Id = UserId
            };
            
            return View("~/Views/SegApp/Mantenimiento/Usuario/EditarRoles.cshtml", model);
        }
    }
}
