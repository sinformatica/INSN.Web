using AutoMapper;
using INSN.Web.Models.Response;
using INSN.Web.Repositories.Interfaces.Mantenimiento.Comunicados;
using INSN.Web.Services.Interfaces.Mantenimiento.Comunicados;
using Microsoft.Extensions.Logging;
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

        #region[Comunicado]
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
        #endregion

        #region[Comunicado detalle]
        /// <summary>
        /// Service: Comunicado Detalle
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<ComunicadoDetalleDtoResponse>>> ComunicadoDetalleListar(int CodigoComunicadoId)
        {
            var response = new BaseResponseGeneric<ICollection<ComunicadoDetalleDtoResponse>>();

            try
            {
                var lista = await _repository.ComunicadoDetalleListar(CodigoComunicadoId);
                response.Data = lista.Select(x => _mapper.Map<ComunicadoDetalleDtoResponse>(x)).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al listar: " + ex.Message;
                _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }
        #endregion
    }
}
