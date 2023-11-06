using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using INSN.Web.Entities.DocumentoLegal;

namespace INSN.Web.DataAccess.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumentoEL>
    {
        public void Configure(EntityTypeBuilder<TipoDocumentoEL> builder)
        {
            builder.Property(p => p.Descripcion).HasMaxLength(70);

            var fecha = DateTime.Parse("2023-11-01");//Fecha de creación original

            // Data Seeding
            builder.HasData(new List<TipoDocumentoEL>()
            {
                new(){ IdTipoDocumento=1, Descripcion = "Resolución Directoral DG", FechaCreacion= fecha,UsuarioCreacion="Administrador", TerminalCreacion="Server"},
                new(){ IdTipoDocumento=2, Descripcion = "Resolución Administrativa OEA", FechaCreacion= fecha,UsuarioCreacion="Administrador", TerminalCreacion="Server"},
                new(){ IdTipoDocumento=2, Descripcion = "Resolución Administrativa OP", FechaCreacion= fecha,UsuarioCreacion="Administrador", TerminalCreacion="Server"},
            });
        }
    }
}