namespace INSN.Web.Models.Request.Home
{
    /// <summary>
    /// Clase EL Documento Legal
    /// </summary>
    public class LibroReclamacionDtoRequest : AuditoriaRequest
    {        
        /// <summary>
        /// Nombre
        /// </summary>
        public string? NroDocumento { get; set; } = default!;

        /// <summary>
        /// Nombre
        /// </summary>
        public string? Nombres { get; set; } = default!;
    }
}
