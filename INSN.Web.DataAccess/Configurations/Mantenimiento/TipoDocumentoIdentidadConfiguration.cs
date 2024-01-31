using INSN.Web.Entities.SegApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations.Mantenimiento
{
    /// <summary>
    /// Configuracion de Tabla Tipo Documento Identidad
    /// </summary>
    public class TipoDocumentoIdentidadConfiguration : IEntityTypeConfiguration<TipoDocumentoIdentidad>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<TipoDocumentoIdentidad> builder)
        {
            builder.Property(p => p.Descripcion)
                 .HasMaxLength(50);

            var fecha = DateTime.Parse("2023-12-10");

            // Data Seeding
            builder.HasData(new List<TipoDocumentoIdentidad>
            {
                new() { Id = 1, Descripcion = "DNI", FechaCreacion = fecha},
                new() { Id = 2, Descripcion = "CARNET DE EXTRANJERÍA", FechaCreacion = fecha},
                new() { Id = 3, Descripcion = "PASAPORTE", FechaCreacion = fecha}
            });
        }
    }
}