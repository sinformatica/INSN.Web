using INSN.Web.Models.Response.SegApp.Mantenimiento;
using System.ComponentModel.DataAnnotations;

namespace INSN.Web.ViewModels.SegApp.Mantenimiento
{
    /// <summary>
    /// Represencacion ViewModel : Rol
    /// </summary>
    public class RolViewModel : BaseModel
    {
        /// <summary>
        /// Lista de Rol
        /// </summary>       
        public ICollection<RolDtoResponse>? Roles { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Display(Name = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Display(Name = "Name")]
        public string? Name { get; set; } = default!;

        public ICollection<BaseModel> Estados { get; } = new List<BaseModel>()
        {
            new() { Codigo = "A", Nombre = "Activo" },
            new() { Codigo = "I", Nombre = "Inactivo" },
        };
    }
}