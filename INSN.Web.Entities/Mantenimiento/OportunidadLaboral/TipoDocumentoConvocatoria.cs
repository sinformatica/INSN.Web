using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.Mantenimiento.OportunidadLaboral
{
    /// <summary>
    /// Entidad Logica de Tipo Documento Convocatoria
    /// </summary>
    public class TipoDocumentoConvocatoria : AuditoriaBase
    {
        /// <summary>
        /// Codigo Tipo Documento Convocatoria Id
        /// </summary>
        public int CodigoTipoDocumentoConvocatoriaId { get; set; }

        /// <summary>
        /// Descripcion del Tipo de Convocatoria
        /// </summary>
        public string? Descripcion { get; set; } = default!;
    }
}