using INSN.Web.Entities.Home.OportunidadLaboral;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations.Home.OportunidadLaboral
{
    /// <summary>
    /// Configuracion de Tabla Documento Convocatoria
    /// </summary>
    public class DocumentoConvocatoriaConfiguration : IEntityTypeConfiguration<DocumentoConvocatoria>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<DocumentoConvocatoria> builder)
        {
        }
    }
}