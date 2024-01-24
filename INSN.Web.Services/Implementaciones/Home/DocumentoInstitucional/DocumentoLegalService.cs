using AutoMapper;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using INSN.Web.Entities.DocumentoInstitucional;
using INSN.Web.Models.Request.Home;
using INSN.Web.Repositories.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.Services.Interfaces.Home.DocumentoInstitucional;

namespace INSN.Web.Services.Implementaciones.Home.DocumentoInstitucional
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
        /// Service: Documento Legal Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<DocumentoLegalDtoResponse>>> DocumentoLegalListar(DocumentoLegalDtoRequest request)
        {
            var response = new BaseResponseGeneric<ICollection<DocumentoLegalDtoResponse>>();

            try
            {
                var lista = await _repository.DocumentoLegalListar(new DocumentoLegal
                {
                    Area = request.Area,
                    CodigoDocumentoLegalId = request.CodigoDocumentoLegalId,
                    Documento = request.Documento,
                    Descripcion = request.Descripcion,
                    CodigoTipoDocumentoId = request.CodigoTipoDocumentoId,
                    Estado = request.Estado,
                    EstadoRegistro = request.EstadoRegistro
                });

                response.Data = lista.Select(x => _mapper.Map<DocumentoLegalDtoResponse>(x)).ToList();

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
