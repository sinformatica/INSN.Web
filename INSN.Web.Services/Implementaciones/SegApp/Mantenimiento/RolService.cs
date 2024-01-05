using AutoMapper;
using INSN.Web.DataAccess;
using INSN.Web.Entities;
using INSN.Web.Entities.Base;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento;
using INSN.Web.Services.Interfaces.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Services.Implementaciones.SegApp.Mantenimiento
{
    /// <summary>
    /// Service Rol
    /// </summary>
    public class RolService : IRolService
    {
        private readonly IRolRepository _repository;
        private readonly ILogger<RolService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public RolService(IRolRepository repository, ILogger<RolService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
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

        //public async Task<BaseResponseGeneric<ICollection<RolDtoResponse>>> RolListar(RolDtoRequest request)
        //{
        //    var response = new BaseResponseGeneric<ICollection<RolDtoResponse>>();

        //    try
        //    {
        //        var roles = await _segAppDbContext.Roles
        //            .Where(r => r.Name.Contains(request.Name))
        //            .Select(r => new INSNIdentityRol // Usar INSNIdentityRol
        //            {
        //                Id = r.Id,
        //                Name = r.Name
        //                //Estado = r.Estado
        //            })
        //            .ToListAsync();

        //        var rolesDto = roles.Select(r => new RolDtoResponse
        //        {
        //            Id = r.Id,
        //            Name = r.Name,
        //            Estado = r.Estado // Obtener el Estado desde Auditoria
        //        }).ToList();

        //        response.Data = rolesDto;
        //        response.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = "Service: Error al listar: " + ex.Message;
        //        _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        //        response.Success = false;
        //    }

        //    return response;
        //}

        // valido
        //public async Task<BaseResponseGeneric<ICollection<RolDtoResponse>>> RolListar(RolDtoRequest request)
        //{
        //    var response = new BaseResponseGeneric<ICollection<RolDtoResponse>>();

        //    try
        //    {
        //        var roles = await _roleManager.Roles
        //            .Where(r => r.Name.Contains(request.Name))
        //            .Select(r => new INSNIdentityRol // Usar INSNIdentityRol
        //            {
        //                Id = r.Id,
        //                Name = r.Name
        //            })
        //            .ToListAsync();

        //        var rolesDto = roles.Select(r => new RolDtoResponse
        //        {
        //            Id = r.Id,
        //            Name = r.Name,
        //            Estado = r.Estado // Obtener el Estado desde Auditoria
        //        }).ToList();

        //        response.Data = rolesDto;
        //        response.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = "Service: Error al listar: " + ex.Message;
        //        _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        //        response.Success = false;
        //    }

        //    return response;
        //}


        //public async Task<BaseResponseGeneric<ICollection<RolDtoResponse>>> RolListar(RolDtoRequest request)
        //{
        //    var response = new BaseResponseGeneric<ICollection<RolDtoResponse>>();

        //    try
        //    {
        //        var roles = await _repository.RolListar(new Rol
        //        {
        //            // Aquí está la parte que no está reconociendo
        //            // Podrías intentar usar un mapeo manual en el repositorio
        //            // o cambiar la forma en que el repositorio maneja el filtrado
        //            // dependiendo de cómo se haya implementado
        //            // Por ejemplo:
        //            IdentityRole = new IdentityRole { Name = request.Name },
        //            Estado = request.Estado,
        //            EstadoRegistro = request.EstadoRegistro
        //        });

        //        response.Data = roles.Select(x => _mapper.Map<RolDtoResponse>(x)).ToList();

        //        response.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = "Service: Error al listar: " + ex.Message;
        //        _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        //    }

        //    return response;
        //}

        //public async Task<BaseResponseGeneric<ICollection<RolDtoResponse>>> RolListar(RolDtoRequest request)
        //{
        //    var response = new BaseResponseGeneric<ICollection<RolDtoResponse>>();

        //    try
        //    {
        //        // Crear un objeto Rol con los campos de búsqueda
        //        var rolRequest = new Rol
        //        {
        //            // Asumiendo que el campo Name está presente en Rol
        //            Name = request.Name
        //        };

        //        // Si el campo Estado y EstadoRegistro están en la clase AuditoriaBase dentro de Rol
        //        if (request.Estado != null || request.EstadoRegistro != default(int))
        //        {
        //            // Verificar si la propiedad Auditoria no es nula
        //            if (rolRequest.Auditoria == null)
        //            {
        //                rolRequest.Auditoria = new AuditoriaBase();
        //            }

        //            // Asignar los valores de Estado y EstadoRegistro a las propiedades de Auditoria
        //            if (request.Estado != null)
        //            {
        //                rolRequest.Auditoria.Estado = request.Estado;
        //            }

        //            if (request.EstadoRegistro != default(int))
        //            {
        //                rolRequest.Auditoria.EstadoRegistro = request.EstadoRegistro;
        //            }
        //        }

        //        // Llamar al método RolListar con el objeto rolRequest
        //        var roles = await _repository.RolListar(rolRequest);

        //        response.Data = roles.Select(x => _mapper.Map<RolDtoResponse>(x)).ToList();
        //        response.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = "Service: Error al listar: " + ex.Message;
        //        _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        //    }

        //    return response;
        //}

        //public async Task<BaseResponseGeneric<ICollection<RolDtoResponse>>> RolListar(RolDtoRequest request)
        //{
        //    var response = new BaseResponseGeneric<ICollection<RolDtoResponse>>();

        //    try
        //    {
        //        var roles = await _repository.RolListar(new Rol
        //        {
        //            Name = request.Name,
        //            Estado = request.Estado,
        //            EstadoRegistro = request.EstadoRegistro
        //        });

        //        response.Data = roles.Select(x => _mapper.Map<RolDtoResponse>(x)).ToList();

        //        response.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = "Service: Error al listar: " + ex.Message;
        //        _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        //    }

        //    return response;
        //}

        /// <summary>
        /// Service: Listar Rol con paginación
        /// </summary>
        /// <param name="Descripcion"></param>
        /// <param name="Estado"></param>
        /// <param name="EstadoRegistro"></param>
        /// <param name="Page"></param>
        /// <param name="Rows"></param>
        /// <returns></returns>
        //public async Task<PaginationResponse<RolDtoResponse>> Listar(string? Name, string? Estado, int EstadoRegistro, int Page, int Rows)
        //{
        //    var response = new PaginationResponse<RolDtoResponse>();

        //    try
        //    {
        //        Expression<Func<Rol, bool>> predicate = x =>
        //            (Name == null || x.Name.Contains(Name))
        //            && (Estado == null || x.Auditoria.Estado == Estado)
        //            && (EstadoRegistro == default || x.Auditoria.EstadoRegistro == EstadoRegistro);

        //        var tupla = await _repository
        //            .Listar<RolDtoResponse, string>(
        //                predicate: predicate,
        //                selector: x => _mapper.Map<RolDtoResponse>(x),
        //                orderBy: p => "Id",
        //                relationships: "Rol", // Eager Loading - EF Core
        //                Page,
        //                Rows);

        //        response.Data = tupla.Collection;
        //        response.TotalPages = tupla.Total / Rows;
        //        if (tupla.Total % Rows > 0)
        //        {
        //            response.TotalPages++;
        //        }

        //        response.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = "Service: Error al Listar: " + ex.Message;
        //        _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
        //    }

        //    return response;
        //}


        //public async Task<PaginationResponse<RolDtoResponse>> Listar(string? Name,
        //    string? Estado, int EstadoRegistro, int Page, int Rows)
        //{
        //    var response = new PaginationResponse<RolDtoResponse>();

        //    try
        //    {
        //        Expression<Func<Rol, bool>> predicate =
        //            x => (Name == null || x.IdentityRole.Name.Contains(Name))
        //            && (Estado == null || x.Estado == Estado)
        //            && (x.EstadoRegistro == EstadoRegistro);

        //        var tupla = await _repository
        //            .Listar<RolDtoResponse, string>(
        //                predicate: predicate,
        //                selector: x => _mapper.Map<RolDtoResponse>(x),
        //                orderBy: p => "Id",
        //                relationships: "Rol", // Eager Loading - EF Core
        //                Page,
        //                Rows);

        //        response.Data = tupla.Collection;
        //        response.TotalPages = tupla.Total / Rows;
        //        if (tupla.Total % Rows > 0)
        //        {
        //            response.TotalPages++;
        //        }

        //        response.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = "Service: Error al Listar: " + ex.Message;
        //        _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
        //    }

        //    return response;
        //}
    }
}
