namespace INSN.Web.Models.Request.SegApp.Mantenimiento
{
    /// <summary>
    /// Clase RolDtoRequest
    /// </summary>
    public class RolDtoRequest : BaseRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string? Name { get; set; } = default!;

        /// <summary>
        /// NormalizedName
        /// </summary>
        public string? NormalizedName { get; set; } = default!;
    }
}