using AutoMapper;
using INSN.Web.DataAccess;
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
using INSN.Web.DataAccess.Acceso;

namespace INSN.Web.Services.Implementaciones.SegApp.Mantenimiento
{
    /// <summary>
    /// Service Usuario Rol
    /// </summary>
    public class UsuarioRolService : IUsuarioRolService
    {
        private readonly IUsuarioRolRepository _repository;
        private readonly ILogger<UsuarioService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<INSNIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SegAppDbContext _segAppDbContext;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public UsuarioRolService(IUsuarioRolRepository repository,
                        ILogger<UsuarioService> logger,
                        IMapper mapper,
                        UserManager<INSNIdentityUser> userManager,
                        RoleManager<IdentityRole> roleManager,
                        SegAppDbContext segAppDbContext)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _userManager = userManager;
            _roleManager = roleManager;
            _segAppDbContext = segAppDbContext;
        }

        /// <summary>
        /// Service: Usuario Rol Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<UsuarioRolDtoResponse>>> UsuarioRolListar(string UserId)
        {
            var response = new BaseResponseGeneric<ICollection<UsuarioRolDtoResponse>>();

            try
            {
                var usuarios = await _repository.UsuarioRolListar(UserId);

                response.Data = usuarios.Select(x => _mapper.Map<UsuarioRolDtoResponse>(x)).ToList();
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
        /// Service: Usuario Rol Asignar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UsuarioRolAsignar(UsuarioRolDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);

                if (user is null)
                {
                    response.ErrorMessage = "Usuario no encontrado";
                    return response;
                }

                var role = await _roleManager.FindByIdAsync(request.RolId);

                if (role != null)
                {
                    // Verificar si el usuario ya tiene el rol para este sistema
                    var existingUserRole = await _segAppDbContext.INSNIdentityUsuarioRol
                        .FirstOrDefaultAsync(ur => ur.UserId == user.Id && ur.CodigoSistemaId == request.CodigoSistemaId && ur.RoleId == role.Id && ur.Estado=="A" && ur.EstadoRegistro==1);

                    if (existingUserRole != null)
                    {
                        response.ErrorMessage = $"El usuario ya cuenta con el rol seleccionado en el sistema indicado.";
                        return response;
                    }

                    // Eliminar roles anteriores del usuario en este sistema
                    //var userRolesInSystem = await _segAppDbContext.INSNIdentityUsuarioRol
                    //    .Where(ur => ur.UserId == user.Id && ur.CodigoSistemaId == request.CodigoSistemaId)
                    //    .ToListAsync();

                    //_segAppDbContext.INSNIdentityUsuarioRol.RemoveRange(userRolesInSystem);
                    //await _segAppDbContext.SaveChangesAsync();

                    // Asignar el nuevo rol al usuario para este sistema
                    var newUserRole = new INSNIdentityUsuarioRol
                    {
                        UserId = user.Id,
                        RoleId = role.Id,
                        CodigoSistemaId = request.CodigoSistemaId
                    };

                    _segAppDbContext.INSNIdentityUsuarioRol.Add(newUserRole);
                    await _segAppDbContext.SaveChangesAsync();

                   //actualizar campos UsuarioCreacion y TerminalCreacion
                   //await _repository.ActualizarCampos(
                   //            predicate: r => (r.UserId == request.UserId
                   //                            && r.RoleId == request.RolId
                   //                            && r.CodigoSistemaId == request.CodigoSistemaId),
                   //            updateAction: r =>
                   //            {
                   //                r.UsuarioCreacion = request.UsuarioCreacion;
                   //                r.TerminalCreacion = Environment.MachineName;
                   //            });
                }
                else
                {
                    response.ErrorMessage = $"Rol no encontrado";
                    return response;
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al asignar roles al usuario";
                _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Serivce: Usuario Rol Eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UsuarioRolEliminar(int Id)
        {
            var response = new BaseResponse();

            try
            {
                await _repository.Eliminar(Id);
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
