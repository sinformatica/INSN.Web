using INSN.Web.Models.Response.Sistemas;

namespace INSN.Web.ViewModels.SegApp
{
    /// <summary>
    /// SistemasViewModel
    /// </summary>
    public class SistemasViewModel
    {
        /// <summary>
        /// Lista Sistema
        /// </summary>
        public ICollection<SistemaDtoResponse>? ListaSistema { get; set; }

        /// <summary>
        /// Usuario Id
        /// </summary>
        public string? UsuarioId { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        public string? Usuario { get; set; }

        /// <summary>
        /// Clave
        /// </summary>
        public string? Clave { get; set; }

        /// <summary>
        /// Confirmar Clave
        /// </summary>
        public string? ConfirmaClave { get; set; }
    }
}