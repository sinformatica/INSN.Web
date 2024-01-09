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
using INSN.Web.DataAccess;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                var user = new INSNIdentityUser
                {
                    Nombres = request.Nombres,
                    ApellidoPaterno = request.ApellidoPaterno,
                    ApellidoMaterno = request.ApellidoMaterno,
                    servicio = request.Servicio,
                    TipoDocumentoIdentidadId = request.TipoDocumentoIdentidadId,
                    DocumentoIdentidad = request.DocumentoIdentidad,
                    UserName = request.UserName,
                    Email = request.Email,
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
                    _mapper.Map(request, registro);
                    await _repository.Actualizar();
                }

                response.Success = registro != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al actualizar: " + ex.Message;
                _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
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
    }
}
