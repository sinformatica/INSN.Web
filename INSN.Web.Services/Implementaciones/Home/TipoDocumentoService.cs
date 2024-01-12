using AutoMapper;
using Microsoft.Extensions.Logging;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home;
using INSN.Web.Repositories.Interfaces.Home;
using INSN.Web.Services.Interfaces.Home;
using INSN.Web.Entities.DocumentoLegal;
using INSN.Web.Models.Request.Home;

namespace INSN.Web.Services.Implementaciones.Home
{
    /// <summary>
    /// Service Tipo Documento
    /// </summary>
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly ITipoDocumentoRepository _repository;
        private readonly ILogger<TipoDocumentoService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public TipoDocumentoService(ITipoDocumentoRepository repository, ILogger<TipoDocumentoService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Service: Tipo Documento Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<TipoDocumentoDtoResponse>>> TipoDocumentoListar(TipoDocumentoDtoRequest request)
        {
            var response = new BaseResponseGeneric<ICollection<TipoDocumentoDtoResponse>>();

            try
            {
                var lista = await _repository.TipoDocumentoListar(new TipoDocumento
                {
                    CodigoTipoDocumentoId = request.CodigoTipoDocumentoId,
                    Descripcion = request.Descripcion,
                    Estado = request.Estado,
                    EstadoRegistro = request.EstadoRegistro
                });

                response.Data = lista.Select(x => _mapper.Map<TipoDocumentoDtoResponse>(x)).ToList();

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
