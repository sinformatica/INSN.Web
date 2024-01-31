using INSN.Web.Entities.SegApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations.Mantenimiento
{
    /// <summary>
    /// Configuracion de Tabla Usuario
    /// </summary>
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
        }
    }
}