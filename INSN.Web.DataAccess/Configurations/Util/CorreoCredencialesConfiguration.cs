using INSN.Web.Entities.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations.Util
{
    /// <summary>
    /// Configuracion de Correo Credenciales
    /// </summary>
    public class CorreoCredencialesConfiguration : IEntityTypeConfiguration<CorreoCredenciales>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CorreoCredenciales> builder)
        {
        }
    }
}