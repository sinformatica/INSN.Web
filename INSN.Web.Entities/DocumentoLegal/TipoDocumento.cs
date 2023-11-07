using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.DocumentoLegal
{
    /// <summary>
    /// Entidad Logica de Tipo Documento
    /// </summary>
    public class TipoDocumento : EntityBase
    {       
        /// <summary>
        /// Descripcion del Tipo de Norma
        /// </summary>
        public string Descripcion { get; set; } = default!;

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
