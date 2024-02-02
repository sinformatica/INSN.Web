using System.ComponentModel.DataAnnotations;

namespace INSN.Web.Entities.SegApp
{
    /// <summary>
    /// Modulo
    /// </summary>
    public class Modulo
    {
        /// <summary>
        /// Codigo Modulo Id
        /// </summary>
        public int CodigoModuloId { get; set; } = default!;

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; } = default!;

        /// <summary>
        /// Controlador
        /// </summary>
        public string Controlador { get; set; } = default!;

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; } = default!;

        /// <summary>
        /// Icono
        /// </summary>
        public string Icono { get; set; } = default!;

        /// <summary>
        /// Codigo Seccion Id
        /// </summary>
        [Required]
        public int CodigoSeccionId { get; set; } = default!;

        /// <summary>
        /// Rol Id
        /// </summary>
        [Required]
        public string RolId { get; set; } = default!;
    }
}