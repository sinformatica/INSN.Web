using AutoMapper;
using INSN.Web.Models.Response;
using Microsoft.Extensions.Logging;
using INSN.Web.Models.Request.Home;
using INSN.Web.Entities.Home.OportunidadLaboral;
using INSN.Web.Repositories.Interfaces.Home.OportunidadLaboral;
using INSN.Web.Services.Interfaces.Home.OportunidadLaboral;
using INSN.Web.Models.Response.Home.OportunidadLaboral;

namespace INSN.Web.Services.Implementaciones.Home.OportunidadLaboral
{
    /// <summary>
    /// Service Documento Convocatoria
    /// </summary>
    public class ConvocatoriaService : IConvocatoriaService
    {
        private readonly IConvocatoriaRepository _repository;
        private readonly ILogger<ConvocatoriaService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public ConvocatoriaService(IConvocatoriaRepository repository, ILogger<ConvocatoriaService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Service: Documento Convocatoria Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<ConvocatoriaDtoResponse>>> DocumentoConvocatoriaListar(ConvocatoriaDtoRequest request)
        {
            var response = new BaseResponseGeneric<ICollection<ConvocatoriaDtoResponse>>();

            try
            {
                var lista = await _repository.DocumentoConvocatoriaListar(new Convocatoria
                {
                    CodigoConvocatoriaId = request.CodigoConvocatoriaId,
                    Descripcion = request.Descripcion,
                    CodigoTipoConvocatoriaId = request.CodigoTipoConvocatoriaId,
                    Estado = request.Estado,
                    EstadoRegistro = request.EstadoRegistro
                });

                response.Data = lista.Select(x => _mapper.Map<ConvocatoriaDtoResponse>(x)).ToList();

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