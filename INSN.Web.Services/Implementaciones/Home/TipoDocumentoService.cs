using AutoMapper;
using Microsoft.Extensions.Logging;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.Home;
using INSN.Web.Repositories.Interfaces.Home;
using INSN.Web.Services.Interfaces.Home;

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
        /// Servicio - Listar Tipo Documento
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<TipoDocumentoDtoResponse>>> ListAsync()
        {
            var response = new BaseResponseGeneric<ICollection<TipoDocumentoDtoResponse>>();

            try
            {
                response.Data = await _repository.ListAsync(x => new TipoDocumentoDtoResponse
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion
                });

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al Listar las Tipo Documentos";
                _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }
    }
}
