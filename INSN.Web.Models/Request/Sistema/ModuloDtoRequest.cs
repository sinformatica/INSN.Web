using System.ComponentModel.DataAnnotations;

namespace INSN.Web.Models.Request.Sistema
{
    /// <summary>
    /// Clase ModuloDtoRequest
    /// </summary>
    public class ModuloDtoRequest
    {
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