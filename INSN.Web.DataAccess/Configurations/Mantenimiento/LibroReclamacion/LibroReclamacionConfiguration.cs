using INSN.Web.Entities.Mantenimiento.LibroReclamacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations.Mantenimiento.OportunidadLaboral
{
    /// <summary>
    /// Configuracion de Tabla Libro Reclamacion
    /// </summary>
    public class LibroReclamacionConfiguration : IEntityTypeConfiguration<LibroReclamacion>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<LibroReclamacion> builder)
        {
        }
    }
}