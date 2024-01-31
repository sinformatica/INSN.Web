using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using INSN.Web.Entities.Home.Comunicados;

namespace INSN.Web.DataAccess.Configurations.Home.Comunicados
{
    /// <summary>
    /// Configuracion de Tabla Comunicado
    /// </summary>
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