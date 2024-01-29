using INSN.Web.Entities.Mantenimiento.DocumentoInstitucional;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations.Mantenimiento.DocumentoInstitucional
{
    /// <summary>
    /// Configuracion de Tabla TDocumento Legal
    /// </summary>
    public class DocumentoLegalConfiguration : IEntityTypeConfiguration<DocumentoLegal>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<DocumentoLegal> builder)
        {
        }
    }
}