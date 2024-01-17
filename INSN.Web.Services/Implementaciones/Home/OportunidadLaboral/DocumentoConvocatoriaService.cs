using AutoMapper;
using INSN.Web.Models.Response;
using Microsoft.Extensions.Logging;
using INSN.Web.Models.Request.Home;
using INSN.Web.Repositories.Interfaces.Home.OportunidadLaboral;
using INSN.Web.Entities.OportunidadLaboral;
using INSN.Web.Models.Response.Home.OportunidadLaboral;
using INSN.Web.Services.Interfaces.Home.OportunidadLaboral;

namespace INSN.Web.Services.Implementaciones.Home.OportunidadLaboral
{
    /// <summary>
    /// Service Documento Convocatoria
    /// </summary>
    public class DocumentoConvocatoriaService : IDocumentoConvocatoriaService
    {
        private readonly IDocumentoConvocatoriaRepository _repository;
        private readonly ILogger<DocumentoConvocatoriaService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public DocumentoConvocatoriaService(IDocumentoConvocatoriaRepository repository, ILogger<DocumentoConvocatoriaService> logger, IMapper mapper)
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
        public async Task<BaseResponseGeneric<ICollection<DocumentoConvocatoriaDtoResponse>>> DocumentoConvocatoriaListar(ConvocatoriaDtoRequest request)
        {
            var response = new BaseResponseGeneric<ICollection<DocumentoConvocatoriaDtoResponse>>();

            try
            {
                var lista = await _repository.DocumentoConvocatoriaListar(new Convocatoria
                {
                    Descripcion = request.Descripcion,
                    CodigoTipoConvocatoriaId = request.CodigoTipoConvocatoriaId,
                    Estado = request.Estado,
                    EstadoRegistro = request.EstadoRegistro
                });

                response.Data = lista.Select(x => _mapper.Map<DocumentoConvocatoriaDtoResponse>(x)).ToList();

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
