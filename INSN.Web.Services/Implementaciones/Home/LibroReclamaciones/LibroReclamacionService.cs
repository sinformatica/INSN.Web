﻿using AutoMapper;
using INSN.Web.Models.Response;
using Microsoft.Extensions.Logging;
using INSN.Web.Entities.Home.LibroReclamacion;
using INSN.Web.Repositories.Interfaces.Home.LibroReclamaciones;
using INSN.Web.Services.Interfaces.Home.LibroReclamaciones;
using INSN.Web.Models.Request.Home.LibroReclamaciones;

namespace INSN.Web.Services.Implementaciones.Home.LibroReclamaciones
{
    /// <summary>
    /// Service Libro Reclamacion
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
                int respuesta = await _repository.Insertar(_mapper.Map<LibroReclamacion>(request));

                if (respuesta == 1)
                {
                    response.Success = true;
                }
                else
                {
                    response.ErrorMessage = "Service: Error al insertar registro";
                    response.Success = false;
                }
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