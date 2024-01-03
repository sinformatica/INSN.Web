using AutoMapper;
using INSN.Web.Entities;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento;
using INSN.Web.Services.Interfaces.SegApp.Mantenimiento;
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
                    Estado = request.Estado,
                    EstadoRegistro = request.EstadoRegistro
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
        /// Service: Listar Rol con paginación
        /// </summary>
        /// <param name="Descripcion"></param>
        /// <param name="Estado"></param>
        /// <param name="EstadoRegistro"></param>
        /// <param name="Page"></param>
        /// <param name="Rows"></param>
        /// <returns></returns>
        public async Task<PaginationResponse<RolDtoResponse>> Listar(string? Name,
            string? Estado, int EstadoRegistro, int Page, int Rows)
        {
            var response = new PaginationResponse<RolDtoResponse>();

            try
            {
                Expression<Func<Rol, bool>> predicate =
                    x => (Name == null || x.Name.Contains(Name))
                    && (Estado == null || x.Estado == Estado)
                    && (x.EstadoRegistro == EstadoRegistro);

                var tupla = await _repository
                    .Listar<RolDtoResponse, string>(
                        predicate: predicate,
                        selector: x => _mapper.Map<RolDtoResponse>(x),
                        orderBy: p => "Id",
                        relationships: "Rol", // Eager Loading - EF Core
                        Page,
                        Rows);

                response.Data = tupla.Collection;
                response.TotalPages = tupla.Total / Rows;
                if (tupla.Total % Rows > 0)
                {
                    response.TotalPages++;
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al Listar: " + ex.Message;
                _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }
    }
}
