﻿using AutoMapper;
using INSN.Web.DataAccess;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento;
using INSN.Web.Services.Interfaces.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using INSN.Web.DataAccess.Acceso;
using INSN.Web.Common;

namespace INSN.Web.Services.Implementaciones.SegApp.Mantenimiento
{
    /// <summary>
    /// UsuarioRolService
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
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="segAppDbContext"></param>
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
        /// <param name="UserId"></param>
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
        public async Task<BaseResponse> UsuarioRolInsertar(UsuarioRolDtoRequest request)
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

                var role = await _roleManager.FindByIdAsync(request.RolId ?? string.Empty);

                if (role != null)
                {
                    // Verificar si el usuario ya algun rol asignado al sistema seleccionado
                    var existingUserRole = await _segAppDbContext.INSNIdentityUsuarioRol
                        .FirstOrDefaultAsync(ur => ur.UserId == user.Id && ur.CodigoSistemaId == request.CodigoSistemaId && ur.Estado == "A" && ur.EstadoRegistro == 1);

                    if (existingUserRole != null)
                    {
                        response.ErrorMessage = Resources.ResourceGeneral.UsuarioRolDuplicado;
                        return response;
                    }

                    // Asignar el nuevo rol al usuario para este sistema
                    var newUserRole = new INSNIdentityUsuarioRol
                    {
                        UserId = user.Id,
                        RoleId = role.Id,
                        CodigoSistemaId = request.CodigoSistemaId,
                        Estado = Enumerado.Estado.Activo,
                        EstadoRegistro = Enumerado.EstadoRegistro.Activo,
                        UsuarioCreacion = request.UsuarioCreacion,
                        TerminalCreacion = Environment.MachineName
                    };

                    _segAppDbContext.INSNIdentityUsuarioRol.Add(newUserRole);
                    await _segAppDbContext.SaveChangesAsync();
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