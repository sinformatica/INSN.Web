using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using INSN.Web.Entities.DocumentoLegal;


namespace INSN.Web.DataAccess.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentoLegalConfiguration : IEntityTypeConfiguration<DocumentoLegalEL>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<DocumentoLegalEL> builder)
        {
            builder.Property(p => p.Documento)
                .HasMaxLength(100);

            builder.Property(p => p.Descripcion)
                .HasMaxLength(1000);

            builder.Property(p => p.PDF)
              .HasMaxLength(1000)
              .IsUnicode(false);

            builder.Property(p => p.FechaPublicacion)
                .HasColumnType("DATE");        
        }
    }
}