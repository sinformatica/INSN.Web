﻿using INSN.Web.Models.Response;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Mantenimiento.DocumentoLegal;

namespace INSN.Web.Services.Interfaces.Mantenimiento.DocumentoInstitucional
{
    /// <summary>
    /// Interface Servicio Documento Legal
    /// </summary>
    public interface IDocumentoLegalService
    {
        /// <summary>
        /// Documento Legal Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<DocumentoLegalDtoResponse>>> DocumentoLegalListar(DocumentoLegalDtoRequest request);
    }
}