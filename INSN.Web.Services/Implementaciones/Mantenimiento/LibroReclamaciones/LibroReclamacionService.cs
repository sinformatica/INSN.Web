﻿using AutoMapper;
using INSN.Web.Models.Response;
using Microsoft.Extensions.Logging;
using INSN.Web.Models.Request.Home;
using INSN.Web.Repositories.Interfaces.Mantenimiento.LibroReclamaciones;
using INSN.Web.Entities.Mantenimiento.LibroReclamacion;
using INSN.Web.Services.Interfaces.Mantenimiento.OportunidadLaboral;

namespace INSN.Web.Services.Implementaciones.Mantenimiento.OportunidadLaboral
{
    /// <summary>
    /// Service Documento Convocatoria
    /// </summary>
    public class LibroReclamacionService : ILibroReclamacionService
    {
        private readonly ILibroReclamacionRepository _repository;
        private readonly ILogger<LibroReclamacionService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public LibroReclamacionService(ILibroReclamacionRepository repository, ILogger<LibroReclamacionService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Service: Libro Reclamacion Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> LibroReclamacionInsertar(LibroReclamacionDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                await _repository.Insertar(_mapper.Map<LibroReclamacion>(request));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al insertar registro: " + ex.Message;
                _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }
    }
}