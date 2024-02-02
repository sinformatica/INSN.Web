using AutoMapper;
using INSN.Web.Entities.SegApp;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento;
using INSN.Web.Services.Interfaces.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace INSN.Web.Services.Implementaciones.SegApp.Mantenimiento
{
    /// <summary>
    /// RolService
    /// </summary>
    public class RolService : IRolService
    {
        private readonly IRolRepository _repository;
        private readonly ILogger<RolService> _logger;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public RolService(IRolRepository repository, ILogger<RolService> logger, 
                        IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Service: Rol Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<RolDtoResponse>>> RolListar(RolDtoRequest request)
        {
            var response = new BaseResponseGeneric<ICollection<RolDtoResponse>>();

            try
            {
                var roles = await _repository.RolListar(new Rol
                {
                    Name = request.Name,
                    Estado = request.Estado
                });

                response.Data = roles.Select(x => _mapper.Map<RolDtoResponse>(x)).ToList();
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
        /// Service: Rol Buscar Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<RolDtoResponse>> RolBuscarId(string Id)
        {
            var response = new BaseResponseGeneric<RolDtoResponse>();

            try
            {
                var data = await _repository.BuscarStringId(Id);

                response.Data = _mapper.Map<RolDtoResponse>(data);
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
        /// Service: Rol Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> RolInsertar(RolDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                // Crear rol
                var role = new IdentityRole(request.Name);

                if (!await _roleManager.RoleExistsAsync(request.Name))
                {
                    // Crear rol con Identity
                    await _roleManager.CreateAsync(role);

                    var createdRole = await _roleManager.FindByNameAsync(request.Name);
                    var data = await _repository.BuscarStringId(createdRole.Id);

                    // actualizar campos UsuarioCreacion y TerminalCreacion
                    await _repository.ActualizarCampos(
                                predicate: r => r.Id == data.Id,
                                updateAction: r =>
                            {
                                r.Estado = request.Estado;
                                r.UsuarioCreacion = request.UsuarioCreacion;
                                r.TerminalCreacion = Environment.MachineName; 
                            });
                }
                    
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al insertar registro: " + ex.Message;
                _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Service: Rol Actualizar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> RolActualizar(RolDtoRequest request)
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
        /// Serivce: Rol Eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BaseResponse> RolEliminar(string Id)
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
        /// Service: Rol Por Sistema Listar
        /// </summary>
        /// <param name="CodigoSistemaId"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<RolDtoResponse>>> RolPorSistemaListar(int CodigoSistemaId)
        {
            var response = new BaseResponseGeneric<ICollection<RolDtoResponse>>();

            try
            {
                var roles = await _repository.RolPorSistemaListar(CodigoSistemaId);

                response.Data = roles.Select(x => _mapper.Map<RolDtoResponse>(x)).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al listar: " + ex.Message;
                _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }
    }
}