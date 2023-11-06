using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.DocumentoLegal
{
    /// <summary>
    /// 
    /// </summary>
    public class TipoDocumentoEL : EntityBaseEL
    {
        /// <summary>
        /// 
        /// </summary>
        public int IdTipoDocumento { get; set; }

        /// <summary>
        /// Descripcion del Tipo de Norma
        /// </summary>
        public string? Descripcion { get; set; } = default!;
    }
}
