﻿using AutoMapper;
using INSN.Web.Entities.DocumentoInstitucional;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response;
using INSN.Web.Repositories.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.Repositories.Interfaces.Mantenimiento.Comunicados;
using INSN.Web.Services.Implementaciones.Home.DocumentoInstitucional;
using INSN.Web.Services.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.Services.Interfaces.Mantenimiento.Comunicados;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Models.Response.Mantenimiento.Comunicados;
using INSN.Web.Models.Request.Mantenimiento.Comunicados;
using INSN.Web.Entities.Mantenimiento.Comunicado;

namespace INSN.Web.Services.Implementaciones.Mantenimiento.Comunicados
{
    public class ComunicadoService : IComunicadoService
    {
        private readonly IComunicadoRepository _repository;
        private readonly ILogger<ComunicadoService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public ComunicadoService(IComunicadoRepository repository, ILogger<ComunicadoService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Service: Comunicado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<ComunicadoDtoResponse>>> ComunicadoListar(ComunicadoDtoRequest request)
        {
            var response = new BaseResponseGeneric<ICollection<ComunicadoDtoResponse>>();

            try
            {
                var lista = await _repository.ComunicadoListar(new Comunicado
                {
                    Titulo = request.Titulo,
                    FechaExpiracion = request.FechaExpiracion,
                    Estado = request.Estado,
                    EstadoRegistro = request.EstadoRegistro
                });

                response.Data = lista.Select(x => _mapper.Map<ComunicadoDtoResponse>(x)).ToList();

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