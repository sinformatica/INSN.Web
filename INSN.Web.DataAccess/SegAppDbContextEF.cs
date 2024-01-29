using INSN.Web.Entities.OportunidadLaboral;
using INSN.Web.Entities.DocumentoInstitucional;
using INSN.Web.Entities.SegApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.DataAccess
{
    /// <summary>
    /// DBContext
    /// </summary>
    public class SegAppDbContextEF : DbContext
    {
        /// <summary>
        /// SegAppDbContextEF
        /// </summary>
        /// <param name="options"></param>
        public SegAppDbContextEF(DbContextOptions<SegAppDbContextEF> options)
            : base(options)
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
            #endregion

            //Se va agregar la configuracion de las entidades desde este mismo ensamblado
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
