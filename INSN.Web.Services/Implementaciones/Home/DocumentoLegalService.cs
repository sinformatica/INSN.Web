using AutoMapper;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response;
using INSN.Web.Repositories.Interfaces.Home;
using INSN.Web.Services.Interfaces.Home;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace INSN.Web.Services.Implementaciones.Home
{
    /// <summary>
    /// Service Documento Legal
    /// </summary>
    public class DocumentoLegalService : IDocumentoLegalService
    {
        private readonly IDocumentoLegalRepository _repository;
        private readonly ILogger<DocumentoLegalService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public DocumentoLegalService(IDocumentoLegalRepository repository, ILogger<DocumentoLegalService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Servicio - Listar Documento Legal
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<DocumentoLegalDtoResponse>>> ListAsync(string? Documento, int? IdTipoDocumento,
            string? Estado, int Page, int Rows)
        {
            var response = new BaseResponseGeneric<ICollection<DocumentoLegalDtoResponse>>();

            try
            {
                var data = await _repository.ListAsync(Documento);

                response.Data = data.Select(_mapper.Map<DocumentoLegalDtoResponse>).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al cargar Documento Legal";
                _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }
    }
}
