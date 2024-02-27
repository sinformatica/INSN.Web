using AutoMapper;
using INSN.Web.Models.Response;
using INSN.Web.Repositories.Interfaces.SegApp;
using INSN.Web.Services.Interfaces.SegApp;
using Microsoft.Extensions.Logging;
using INSN.Web.Models.Response.Sistemas;

namespace INSN.Web.Services.Implementaciones.SegApp
{
    /// <summary>
    /// SistemaService
    /// </summary>
    public class SistemaService : ISistemaService
    {
        private readonly ISistemaRepository _repository;
        private readonly ILogger<SistemaService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Instanciar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public SistemaService(ISistemaRepository repository,
                                        ILogger<SistemaService> logger,
                                        IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Service: Sistema
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<SistemaDtoResponse>>> SistemaListar()
        {
            var response = new BaseResponseGeneric<ICollection<SistemaDtoResponse>>();

            try
            {
                var TipoDocs = await _repository.SistemaListar();

                response.Data = TipoDocs.Select(x => _mapper.Map<SistemaDtoResponse>(x)).ToList();
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