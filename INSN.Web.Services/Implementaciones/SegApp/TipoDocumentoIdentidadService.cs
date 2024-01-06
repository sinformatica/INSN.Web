using AutoMapper;
using INSN.Web.Entities;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Repositories.Interfaces.SegApp;
using INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento;
using INSN.Web.Services.Implementaciones.SegApp.Mantenimiento;
using INSN.Web.Services.Interfaces.SegApp;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Models.Response.SegApp;
using INSN.Web.Models.Request.SegApp;

namespace INSN.Web.Services.Implementaciones.SegApp
{
    /// <summary>
    /// Service Tipo Documento Identidad
    /// </summary>
    public class TipoDocumentoIdentidadService : ITipoDocumentoIdentidadService
    {
        private readonly ITipoDocumentoIdentidadRepository _repository;
        private readonly ILogger<RolService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public TipoDocumentoIdentidadService(ITipoDocumentoIdentidadRepository repository, 
                                        ILogger<RolService> logger,
                                        IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Service: Tipo Documento Identidad Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<TipoDocumentoIdentidadDtoResponse>>> TipoDocumentoIdentidadListar()
        {
            var response = new BaseResponseGeneric<ICollection<TipoDocumentoIdentidadDtoResponse>>();

            try
            {
                var TipoDocs = await _repository.TipoDocumentoIdentidadListar();

                response.Data = TipoDocs.Select(x => _mapper.Map<TipoDocumentoIdentidadDtoResponse>(x)).ToList();
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
