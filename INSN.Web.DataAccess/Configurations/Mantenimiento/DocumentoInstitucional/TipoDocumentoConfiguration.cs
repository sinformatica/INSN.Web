using INSN.Web.Entities.Mantenimiento.DocumentoInstitucional;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations.Mantenimiento.DocumentoInstitucional
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
        }
    }
}