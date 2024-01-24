using INSN.Web.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Entities.SegApp
{
    public class TipoDocumentoIdentidad : AuditoriaBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Abreviatura
        /// </summary>
        public string? Abreviatura { get; set; }
    }
}
