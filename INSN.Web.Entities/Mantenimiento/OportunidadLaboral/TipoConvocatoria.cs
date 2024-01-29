using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.Mantenimiento.OportunidadLaboral
{
    /// <summary>
    /// Entidad Logica de Tipo Convocatoria
    /// </summary>
    public class TipoConvocatoria : AuditoriaBase
    {
        /// <summary>
        /// Codigo Tipo Convocatoria Id
        /// </summary>
        public int CodigoTipoConvocatoriaId { get; set; }

        /// <summary>
        /// Descripcion del Tipo de Convocatoria
        /// </summary>
        public string? Descripcion { get; set; } = default!;
    }
}