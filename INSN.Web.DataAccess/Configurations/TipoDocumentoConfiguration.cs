using INSN.Web.Entities.DocumentoLegal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations
{
    /// <summary>
    /// Configuracion de Tabla Tipo Documento
    /// </summary>
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<TipoDocumento> builder)
        {
            builder.Property(p => p.Descripcion)
                 .HasMaxLength(50);
        }
    }
}