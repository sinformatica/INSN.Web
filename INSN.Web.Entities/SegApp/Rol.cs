using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.SegApp
{
    /// <summary>
    /// Entidad Logica Rol
    /// </summary>
    public class Rol : AuditoriaBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; } = default!;

        /// <summary>
        /// Name
        /// </summary>      
        public string Name { get; set; } = default!;

        /// <summary>
        /// Normalized Name
        /// </summary>
        public string? NormalizedName { get; set; }

        /// <summary>
        /// Concurrency Stamp
        /// </summary>
        public string? ConcurrencyStamp { get; set; }
    }
}