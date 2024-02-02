using INSN.Web.Models.Response.SegApp;

namespace INSN.Web.ViewModels.SegApp
{
    /// <summary>
    /// TipoDocumentoIdentidadViewModel
    /// </summary>
    public class TipoDocumentoIdentidadViewModel : BaseModel
    {
        /// <summary>
        /// Lista de Tipos Documento Identidad
        /// </summary>       
        public ICollection<TipoDocumentoIdentidadDtoResponse>? TiposDocIdentidad { get; set; }

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