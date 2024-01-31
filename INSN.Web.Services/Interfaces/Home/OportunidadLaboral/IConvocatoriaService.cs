﻿using INSN.Web.Models.Response;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home.OportunidadLaboral;

namespace INSN.Web.Services.Interfaces.Home.OportunidadLaboral
{
    /// <summary>
    /// Interface Servicio Convocatoria
    /// </summary>
    public interface IConvocatoriaService
    {
        /// <summary>
        /// Documento Convocatoria Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<ConvocatoriaDtoResponse>>> DocumentoConvocatoriaListar(ConvocatoriaDtoRequest request);
    }
}