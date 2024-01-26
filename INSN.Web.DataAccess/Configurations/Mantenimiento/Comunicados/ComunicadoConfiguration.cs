using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using INSN.Web.Entities.Mantenimiento.Comunicado;

namespace INSN.Web.DataAccess.Configurations.Mantenimiento.Comunicados
{
    public class ComunicadoConfiguration : IEntityTypeConfiguration<Comunicado>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Comunicado> builder)
        {
        }
    }
}
