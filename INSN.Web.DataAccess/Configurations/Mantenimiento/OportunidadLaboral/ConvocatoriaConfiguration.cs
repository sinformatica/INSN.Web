using INSN.Web.Entities.Mantenimiento.OportunidadLaboral;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations.Mantenimiento.OportunidadLaboral
{
    /// <summary>
    /// Configuracion de Tabla Convocatoria
    /// </summary>
    public class ConvocatoriaConfiguration : IEntityTypeConfiguration<Convocatoria>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Convocatoria> builder)
        {
        }
    }
}