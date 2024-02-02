using INSN.Web.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace INSN.Web.Entities.SegApp
{
    /// <summary>
    /// Seccion
    /// </summary>
    public class Seccion : AuditoriaBase
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

        /// <summary>
        /// Codigo Sistema Id
        /// </summary>
        [Required]
        public int CodigoSistemaId { get; set; } = default!;

        /// <summary>
        /// Rol Id
        /// </summary>
        [Required]
        public string RolId { get; set; } = default!;
    }
}