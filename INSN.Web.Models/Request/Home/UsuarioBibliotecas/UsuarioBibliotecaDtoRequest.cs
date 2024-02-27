namespace INSN.Web.Models.Request.Home.UsuarioBibliotecas
{
    /// <summary>
    /// Clase EL Usuario Biblioteca
    /// </summary>
    public class UsuarioBibliotecaDtoRequest : AuditoriaRequest
    {
        /// <summary>
        /// User Name
        /// </summary>
        public string? UserName { get; set; } = default!;

        /// <summary>
        /// Fecha Login
        /// </summary>
        public DateTime? FechaLogin { get; set; }
    }
}