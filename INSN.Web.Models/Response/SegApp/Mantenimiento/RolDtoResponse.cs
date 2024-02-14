namespace INSN.Web.Models.Response.SegApp.Mantenimiento
{
    /// <summary>
    /// Clase Rol Dto Response
    /// </summary>
    public class RolDtoResponse : BaseResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; } = default!;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = default!;
    }
}