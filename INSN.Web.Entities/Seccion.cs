using INSN.Web.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Entities
{
    public class Seccion :EntityBase
    {
        /// <summary>
        /// Codigo Seccion Id
        /// </summary>
        public int CodigoSeccionId { get; set; } = default!;

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; } = default!;

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; } = default!;

        /// <summary>
        /// Icono
        /// </summary>
        public string Icono { get; set; } = default!;

        [Required]
        public int CodigoSistemaId { get; set; } = default!;

        [Required]
        public string RolId { get; set; } = default!;
    }
}
