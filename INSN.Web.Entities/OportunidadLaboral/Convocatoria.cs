using INSN.Web.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace INSN.Web.Entities.OportunidadLaboral
{
    /// <summary>
    /// Entidad Logica : Convocatoria
    /// </summary>
    public class Convocatoria : AuditoriaBase
    {
        /// <summary>
        /// Codigo Convocatoria Id
        /// </summary>
        public int? CodigoConvocatoriaId { get; set; }

        /// <summary>
        /// Descripcion de la Convocatoria
        /// </summary>
        public string? Descripcion { get; set; } = default!;

        /// <summary>
        /// Tipo Convocatoria
        /// </summary>
        [ForeignKey("CodigoTipoConvocatoriaId")]
        public TipoConvocatoria TipoConvocatoria { get; set; } = default!;

        /// <summary>
        /// Codigo Tipo Convocatoria Id
        /// </summary>
        public int CodigoTipoConvocatoriaId { get; set; } = default!;

        /// <summary>
        /// Fecha Inicio
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha Inicio
        /// </summary>
        public DateTime FechaFinal { get; set; }      
    }
}