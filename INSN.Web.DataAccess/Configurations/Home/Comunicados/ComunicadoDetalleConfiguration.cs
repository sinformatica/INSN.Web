using INSN.Web.Entities.Home.Comunicados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations.Home.Comunicados
{
    /// <summary>
    /// Configuracion de Tabla Comunicado Detalle
    /// </summary>
    public class ComunicadoDetalleConfiguration : IEntityTypeConfiguration<ComunicadoDetalle>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ComunicadoDetalle> builder)
        {
        }
    }
}