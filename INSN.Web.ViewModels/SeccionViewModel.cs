using INSN.Web.Models.Response.Sistema;

namespace INSN.Web.ViewModels
{
    public class SeccionViewModel
    {
        /// <summary>
        /// Seccion Lista
        /// </summary>
        public ICollection<SeccionDtoResponse>? SeccionLista { get; set; }
    }
}