using INSN.Web.Models.Response.Sistema;

namespace INSN.Web.ViewModels
{
    /// <summary>
    /// SeccionViewModel
    /// </summary>
    public class SeccionViewModel
    {
        /// <summary>
        /// Seccion Lista
        /// </summary>
        public ICollection<SeccionDtoResponse>? SeccionLista { get; set; }
    }
}