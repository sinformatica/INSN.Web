using System.ComponentModel.DataAnnotations;

namespace INSN.Web.Models.Request.Sistema
{
    /// <summary>
    /// Clase SeccionDtoRequest
    /// </summary>
    public class SeccionDtoRequest
    {
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