namespace INSN.Web.Models.Response.Home.UsuarioBibliotecas
{
    /// <summary>
    /// Clase Usuario Biblioteca Dto Response
    /// </summary>
    public class UsuarioBibliotecaDtoResponse : BaseResponse
    {
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; } = default!;

        /// <summary>
        /// Fecha Login
        /// </summary>
        public DateTime FechaLogin { get; set; } = default!;
    }
}