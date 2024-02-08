using INSN.Web.Models.Response.SegApp.Mantenimiento;
using System.ComponentModel.DataAnnotations;

namespace INSN.Web.ViewModels.SegApp.Mantenimiento
{
    /// <summary>
    /// RolViewModel
    /// </summary>
    public class RolViewModel : BaseModel
    {
        /// <summary>
        /// Lista de Rol
        /// </summary>       
        public ICollection<RolDtoResponse>? Roles { get; set; } = default!;

        /// <summary>
        /// Id
        /// </summary>
        [Display(Name = "Id")]
        public string? Id { get; set; } = default!;

        /// <summary>
        /// Name
        /// </summary>
        [Display(Name = "Name")]
        public string? Name { get; set; } = default!;

        /// <summary>
        /// Estados
        /// </summary>
        public ICollection<BaseModel> Estados { get; } = new List<BaseModel>()
        {
            new() { Codigo = "A", Nombre = "Activo" },
            new() { Codigo = "I", Nombre = "Inactivo" },
        };
    }
}