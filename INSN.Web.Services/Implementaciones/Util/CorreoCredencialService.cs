using AutoMapper;
using INSN.Web.Models.Response;
using INSN.Web.Repositories.Interfaces.Util;
using INSN.Web.Services.Interfaces.Util;
using Microsoft.Extensions.Logging;
using INSN.Web.Models.Response.Util;

namespace INSN.Web.Services.Implementaciones.Util
{
    /// <summary>
    /// Correo Credencial Service
    /// </summary>
    public class CorreoCredencialService : ICorreoCredencialService
    {
        private readonly ICorreoCredencialRepository _repository;
        private readonly ILogger<CorreoCredencialService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public CorreoCredencialService(ICorreoCredencialRepository repository, ILogger<CorreoCredencialService> logger,
                                        IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Service: Obtener Correo Credencial
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<CorreoCredencialDtoResponse>> ObtenerCorreoCredencial()
        {
            var response = new BaseResponseGeneric<CorreoCredencialDtoResponse>();

            try
            {
                var data = await _repository.BuscarId(1);
                response.Data = _mapper.Map<CorreoCredencialDtoResponse>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al buscar: " + ex.Message;
                _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }
    }
}