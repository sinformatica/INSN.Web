﻿namespace INSN.Web.Models.Response.SegApp
{
    /// <summary>
    /// Clase TipoDocumentoIdentidadDtoResponse
    /// </summary>
    public class TipoDocumentoIdentidadDtoResponse : BaseResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; } = default!;

        /// <summary>
        /// Abreviatura
        /// </summary>
        public string Abreviatura { get; set; } = default!;
    }
}