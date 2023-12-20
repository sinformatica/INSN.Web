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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using INSN.Web.Entities.DocumentoLegal;

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
        /// 
        /// </summary>
        /// <param name="Documento"></param>
        /// <param name="TipoDocumentoId"></param>
        /// <param name="Estado"></param>
        /// <param name="Page"></param>
        /// <param name="Rows"></param>
        /// <returns></returns>
        public async Task<PaginationResponse<DocumentoLegalDtoResponse>> ListAsync(string? Documento, string? Descripcion,string? Area, int? TipoDocumentoId,
            string? Estado, int EstadoRegistro, int Page, int Rows)
        {

            var response = new PaginationResponse<DocumentoLegalDtoResponse>();

            try
            {
                Expression<Func<DocumentoLegal, bool>> predicate =
    x => x.Documento.Contains(Documento ?? string.Empty)
    && (string.IsNullOrEmpty(Descripcion) || x.Descripcion.Contains(Descripcion))
    && (string.IsNullOrEmpty(Area) || x.TipoDocumento.Area.Contains(Area))
    && (TipoDocumentoId == null || x.TipoDocumentoId == TipoDocumentoId)
    && (Estado == null || x.Estado == Estado) &&
    (x.EstadoRegistro == EstadoRegistro);

                var tupla = await _repository
                    .ListAsync<DocumentoLegalDtoResponse, string>(
                        predicate: predicate,
                        selector: x => _mapper.Map<DocumentoLegalDtoResponse>(x),
                        orderBy: p => p.Documento,
                        relationships: "DocumentoLegal,TipoDocumento", // Eager Loading - EF Core
                        Page,
                        Rows);

                response.Data = tupla.Collection;
                response.TotalPages = tupla.Total / Rows;
                if (tupla.Total % Rows > 0)
                {
                    response.TotalPages++;
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al Listar los DocumentoLegales";
                _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;

        }
    }
}
