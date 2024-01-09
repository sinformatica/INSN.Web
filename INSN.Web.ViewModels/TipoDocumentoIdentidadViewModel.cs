using INSN.Web.Models;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.ViewModels
{
    /// <summary>
    /// Represencacion ViewModel : Tipo Documento Identidad
    /// </summary>
    public class TipoDocumentoIdentidadViewModel : BaseModel
    {
        /// <summary>
        /// Lista de Tipos Documento Identidad
        /// </summary>       
        public ICollection<TipoDocumentoIdentidadDtoResponse>? TiposDocIdentidad { get; set; }

        public ICollection<BaseModel> Estados { get; } = new List<BaseModel>()
        {
            new() { Codigo = "A", Nombre = "Activo" },
            new() { Codigo = "I", Nombre = "Inactivo" },
        };
    }
}
