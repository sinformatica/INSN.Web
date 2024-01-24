using INSN.Web.Entities.OportunidadLaboral;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations
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