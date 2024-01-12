using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Models.Response;

namespace INSN.Web.Models.Response.SegApp
{
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
