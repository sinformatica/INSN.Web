using AutoMapper;
using INSN.Web.Entities.SegApp;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento;
using INSN.Web.Services.Interfaces.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Data.SqlClient;
using INSN.Web.DataAccess.Acceso;

namespace INSN.Web.Services.Implementaciones.SegApp.Mantenimiento
{
    /// <summary>
    /// Service Usuario
    /// </summary>
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly ILogger<UsuarioService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<INSNIdentityUser> _userManager;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public UsuarioService(IUsuarioRepository repository, 
                        ILogger<UsuarioService> logger,
                        IMapper mapper,
                        UserManager<INSNIdentityUser> userManager)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _userManager = userManager;
        }

        /// <summary>
        /// Service: Usuario Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<UsuarioDtoResponse>>> UsuarioListar(UsuarioDtoRequest request)
        {
            var response = new BaseResponseGeneric<ICollection<UsuarioDtoResponse>>();

            try
            {
                var usuarios = await _repository.UsuarioListar(new Usuario
                {
                    UserName = request.UserName,
                    Nombres = request.Nombres,
                    Estado = request.Estado
                });

                response.Data = usuarios.Select(x => _mapper.Map<UsuarioDtoResponse>(x)).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al listar: " + ex.Message;
                _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Service: Usuario Buscar Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<UsuarioDtoResponse>> UsuarioBuscarId(string Id)
        {
            var response = new BaseResponseGeneric<UsuarioDtoResponse>();

            try
            {
                var data = await _repository.BuscarStringId(Id);
                response.Data = _mapper.Map<UsuarioDtoResponse>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al buscar: " + ex.Message;
                _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Service: Usuario Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UsuarioInsertar(UsuarioDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                // Verificar si el usuario ya existe
                //var ExisteUsuario = await _userManager.FindByNameAsync(request.UserName);

                //if (ExisteUsuario != null)
                //{
                //    // El usuario ya existe, realiza las operaciones necesarias (por ejemplo, concatenar la letra al usuario)
                //    ExisteUsuario.UserName += request.ApellidoMaterno?.FirstOrDefault().ToString().ToUpper();
                //}
                
                var user = new INSNIdentityUser
                {
                    Nombres = request.Nombres,
                    ApellidoPaterno = request.ApellidoPaterno,
                    ApellidoMaterno = request.ApellidoMaterno,
                    servicio = request.Servicio,
                    TipoDocumentoIdentidadId = request.TipoDocumentoIdentidadId,
                    DocumentoIdentidad = request.DocumentoIdentidad,
                    UserName = request.UserName,
                    NormalizedUserName = request.UserName.ToUpper(),
                    Email = request.Email,
                    NormalizedEmail = request.Email.ToUpper(),
                    PhoneNumber = request.PhoneNumber,
                    Telefono2 = request.Telefono2,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    // actualizar campos UsuarioCreacion y TerminalCreacion
                    var data = await _userManager.FindByEmailAsync(user.Email);

                    await _repository.ActualizarCampos(
                                predicate: r => r.Id == data.Id,
                                updateAction: r =>
                                {
                                    r.UsuarioCreacion = request.UsuarioCreacion;
                                    r.TerminalCreacion = Environment.MachineName;
                                });
                }
                else
                {
                    var sb = new StringBuilder();

                    var errorMessages = new HashSet<string>(); // Conjunto para almacenar mensajes de error únicos

                    foreach (var error in result.Errors)
                    {
                        // Buscar el mensaje de error personalizado en español desde los recursos
                        var errorMessage = Resources.ResourceGeneral.ResourceManager.GetString(error.Code);
                        
                        // Si no se encuentra un mensaje personalizado, usa la descripción predeterminada del error
                        errorMessage = errorMessage ?? error.Description;

                        if (!errorMessages.Contains(errorMessage))
                        {
                            sb.Append($"{errorMessage}. ");
                            errorMessages.Add(errorMessage); // Agregar mensaje al conjunto
                        }
                    }

                    // Mensajes únicos de errores concatenados en sb
                    response.ErrorMessage = sb.ToString();
                    sb.Clear(); // Liberar la memoria
                }

                response.Success = result.Succeeded;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al insertar registro: " + ex.Message;
                _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Service: Usuario Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UsuarioActualizar(UsuarioDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var registro = await _repository.BuscarStringId(request.Id);

                if (registro is not null)
                {
                    // Verificamos si otro usuario ya tiene el mismo email
                    var existingUserWithEmail = await _userManager.FindByEmailAsync(request.Email);

                    if (existingUserWithEmail != null && existingUserWithEmail.Id != registro.Id)
                    {
                        // Si encontramos otro usuario con el mismo email pero con diferente ID, indicamos que el email ya está en uso
                        response.ErrorMessage = Resources.ResourceGeneral.DuplicateEmail;
                        _logger.LogError(response.ErrorMessage);
                        response.Success = false;
                        return response;
                    }

                    _mapper.Map(request, registro);
                    await _repository.Actualizar();
                }

                response.Success = registro != null;
            }
            catch (DbUpdateException ex) // Capturamos la excepción de actualización de la base de datos
            {
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2601) // Verificamos el número de error específico de SQL Server
                {
                    response.ErrorMessage = Resources.ResourceGeneral.DuplicateUserName; // Utilizamos un recurso para el mensaje específico
                    _logger.LogError(ex, response.ErrorMessage);
                }
                else
                {
                    response.ErrorMessage = "Service: Error al actualizar: " + ex.Message; // Otras excepciones de DbUpdateException
                    _logger.LogError(ex, response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al actualizar: " + ex.Message; // Otras excepciones genéricas
                _logger.LogError(ex, response.ErrorMessage);
            }

            return response;
        }

        /// <summary>
        /// Serivce: Usuario Eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UsuarioEliminar(string Id)
        {
            var response = new BaseResponse();

            try
            {
                await _repository.EliminarString(Id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al eliminar: " + ex.Message;
                _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Serivce: Usuario Actualizar Clave
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UsuarioActualizarClave(UsuarioDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var result = await _userManager.ResetPasswordAsync(user, token, request.Password);

                    if (result.Succeeded)
                    {
                        response.Success = true;
                    }
                    else
                    {
                        response.Success = false;
                        var sb = new StringBuilder();

                        var errorMessages = new HashSet<string>();

                        foreach (var error in result.Errors)
                        {
                            var errorMessage = Resources.ResourceGeneral.ResourceManager.GetString(error.Code);
                            errorMessage = errorMessage ?? error.Description;

                            if (!errorMessages.Contains(errorMessage))
                            {
                                sb.Append($"{errorMessage}. ");
                                errorMessages.Add(errorMessage);
                            }
                        }

                        response.ErrorMessage = sb.ToString();
                    }
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = Resources.ResourceGeneral.UserNotFound;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Error al actualizar contraseña " + ex.Message;
                _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }
    }
}
