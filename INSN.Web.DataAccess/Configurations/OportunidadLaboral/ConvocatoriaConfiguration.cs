using INSN.Web.Entities.OportunidadLaboral;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations
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