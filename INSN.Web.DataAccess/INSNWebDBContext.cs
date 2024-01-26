using INSN.Web.Entities.SegApp;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using INSN.Web.Entities.Mantenimiento.Comunicado;
using INSN.Web.Entities.Mantenimiento.OportunidadLaboral;
using INSN.Web.Entities.Mantenimiento.DocumentoInstitucional;

namespace INSN.Web.DataAccess
{
    /// <summary>
    /// DBContext
    /// </summary>
    public class INSNWebDBContext : DbContext
    {
        /// <summary>
        /// INSNWebDBContext
        /// </summary>
        /// <param name="options"></param>
        public INSNWebDBContext(DbContextOptions< INSNWebDBContext> options ) 
            : base( options ) 
        {         
        }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region [Declarar Identificador de Tabla]
            #region [DocumentoInstitucional]
            modelBuilder.Entity<DocumentoLegal>().HasKey(f => f.CodigoDocumentoLegalId);
            modelBuilder.Entity<TipoDocumento>().HasKey(f => f.CodigoTipoDocumentoId);
            #endregion

            #region [SegApp]
            modelBuilder.Entity<Rol>().HasKey(f => f.Id);
            modelBuilder.Entity<Usuario>().HasKey(f => f.Id);
            modelBuilder.Entity<Sistema>().HasKey(f => f.CodigoSistemaId);
            modelBuilder.Entity<UsuarioRol>().HasKey(f => f.CodigoUsuarioRolId);
            #endregion

            #region [Oportunidad Laboral]
            modelBuilder.Entity<Convocatoria>().HasKey(f => f.CodigoConvocatoriaId);
            modelBuilder.Entity<TipoConvocatoria>().HasKey(f => f.CodigoTipoConvocatoriaId);
            modelBuilder.Entity<TipoDocumentoConvocatoria>().HasKey(f => f.CodigoTipoDocumentoConvocatoriaId);
            modelBuilder.Entity<DocumentoConvocatoria>().HasKey(f => f.CodigoDocumentoConvocatoriaId);
            #endregion

            #region [Mantenimiento - Comunicado]
            modelBuilder.Entity<Comunicado>().HasKey(f => f.CodigoComunicadoId);
            modelBuilder.Entity<ComunicadoDetalle>().HasKey(f => f.CodigoComunicadoDetId);
            #endregion
            #endregion

            //Se va agregar la configuracion de las entidades desde este mismo ensamblado
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}