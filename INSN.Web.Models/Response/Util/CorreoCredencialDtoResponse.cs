namespace INSN.Web.Models.Response.Util
{
    /// <summary>
    /// Correo Credencial Dto Response
    /// </summary>
    public class CorreoCredencialDtoResponse : BaseResponse
    {
        /// <summary>
        /// Codigo Correo Credencial Id
        /// </summary>
        public int CodigoCorreoCredencialId { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        public string? Usuario { get; set; } = default!;

        /// <summary>
        /// Clave
        /// </summary>
        public string? Clave { get; set; } = default!;

        /// <summary>
        /// Host
        /// </summary>
        public string? Host { get; set; } = default!;

        /// <summary>
        /// Puerto
        /// </summary>
        public int Puerto { get; set; }
    }
}