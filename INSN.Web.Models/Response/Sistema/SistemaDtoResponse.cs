namespace INSN.Web.Models.Response.Sistemas
{
    /// <summary>
    /// Clase SistemaDtoResponse
    /// </summary>
    public class SistemaDtoResponse : BaseResponse
    {
        /// <summary>
        /// Codigo Sistema Id
        /// </summary>
        public int CodigoSistemaId { get; set; } = default!;

        /// <summary>
        /// Descripcion
        /// </summary>
        public string descripcion { get; set; } = default!;

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; } = default!;

        /// <summary>
        /// Icono
        /// </summary>
        public string Icono { get; set; } = default!;

        /// <summary>
        /// Target
        /// </summary>
        public string Target { get; set; } = default!;

        /// <summary>
        /// UsarToken
        /// </summary>
        public int UsarToken { get; set; } = default!;
    }
}