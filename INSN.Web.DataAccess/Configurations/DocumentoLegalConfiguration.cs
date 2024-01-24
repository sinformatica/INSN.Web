using INSN.Web.Entities.DocumentoLegal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations
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