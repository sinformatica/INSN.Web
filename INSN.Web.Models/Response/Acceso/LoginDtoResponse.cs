namespace INSN.Web.Models.Response.Acceso
{
    /// <summary>
    /// Clase LoginDtoResponse
    /// </summary>
    public class LoginDtoResponse : BaseResponse
    {
        /// <summary>
        /// Nombres Completos
        /// </summary>
        public string NombresCompletos { get; set; } = default!;

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; } = default!;
    }
}