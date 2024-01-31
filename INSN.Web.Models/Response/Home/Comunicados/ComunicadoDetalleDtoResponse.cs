﻿namespace INSN.Web.Models.Response.Home.Comunicados
{
    /// <summary>
    /// Clase ComunicadoDetalleDtoResponse
    /// </summary>
    public class ComunicadoDetalleDtoResponse : BaseResponse
    {
        /// <summary>
        /// Codigo Comunicado Id
        /// </summary>
        public int? CodigoComunicadoDetId { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public int CodigoComunicadoId { get; set; }

        /// <summary>
        /// Ruta Imagen
        /// </summary>
        public string? RutaImagen { get; set; }
    }
}