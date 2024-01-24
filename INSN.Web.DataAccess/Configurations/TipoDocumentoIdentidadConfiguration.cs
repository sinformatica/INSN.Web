using INSN.Web.Entities.SegApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.DataAccess.Configurations
{
    public class TipoDocumentoIdentidadConfiguration : IEntityTypeConfiguration<TipoDocumentoIdentidad>
    {
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
