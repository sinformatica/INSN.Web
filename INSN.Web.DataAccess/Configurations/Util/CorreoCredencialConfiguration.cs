using INSN.Web.Entities.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations.Util
{
    /// <summary>
    /// Configuracion de Correo Credencial
    /// </summary>
    public class CorreoCredencialConfiguration : IEntityTypeConfiguration<CorreoCredencial>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CorreoCredencial> builder)
        {
        }
    }
}