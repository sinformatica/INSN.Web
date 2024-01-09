using INSN.Web.Models;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Interfaces;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public UsuarioController(IUsuarioProxy proxy,
                                ILogger<UsuarioController> logger,
                                IWebHostEnvironment env, ITipoDocumentoIdentidadProxy proxyTipoDoc)
        {
            _proxy = proxy;
            _logger = logger;
            _enviroment = env;
            _proxyTipoDoc = proxyTipoDoc;
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
                Nombre = response.Nombres
            };

            var resultTiposDoc = TipoDocumentoIdentidadListar();
            model.TiposDocIdentidad = resultTiposDoc.Result;

            return View("~/Views/Mantenimiento/Producto/Editar.cshtml", model);
        }

        /// <summary>
        /// Producto Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //public async Task<IActionResult> ProductoActualizar(ProductoViewModel request)
        //{
        //    var response = await _proxy.ProductoBuscarId(request.CodigoProductoId);

        //    if (response is null)
        //    {
        //        ModelState.AddModelError("ID", "No se encontro el registro");
        //        return View();
        //    }

        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(request.Descripcion))
        //        {
        //            throw new ModelException(nameof(request.Descripcion), "Campo requerido: Descripción");
        //        }

        //        var dtoRequest = new ProductoDtoRequest
        //        {
        //            CodigoProductoId = request.CodigoProductoId,
        //            Descripcion = request.Descripcion,
        //            Estado = request.EstadoSeleccionado,
        //            #region [Base Update]
        //            EstadoRegistro = 1,
        //            FechaCreacion = response.FechaCreacion,
        //            UsuarioCreacion = response.UsuarioCreacion,
        //            TerminalCreacion = response.TerminalCreacion,
        //            TerminalModificacion = Environment.MachineName,
        //            UsuarioModificacion = Environment.UserName, //Modificar por Usuario de sesion logueada
        //            FechaModificacion = DateTime.Now
        //            #endregion
        //        };

        //        await _proxy.ProductoActualizar(dtoRequest);

        //        return RedirectToAction(nameof(Index));

        //    }
        //    catch (ModelException ex)
        //    {
        //        ModelState.AddModelError(ex.PropertyName, ex.Message);
        //        _logger.LogError(ex, "Validación de registro {Message}", ex.Message);
        //        return View("~/Views/Mantenimiento/Producto/Editar.cshtml", request);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Modificación de Producto {Message}", ex.Message);
        //        return View("~/Views/Mantenimiento/Producto/Editar.cshtml", request);
        //    }
        //}
        #endregion
    }
}
