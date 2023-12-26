﻿namespace INSN.Web.Models.Response.Sistemas
{
    public class SistemasDtoResponse : BaseResponse
    {

        public int CodigoSistemaId { get; set; } = default!;
        public string descripcion { get; set; } = default!;
        public string url { get; set; } = default!;
        public string icono { get; set; } = default!;
    }
}
