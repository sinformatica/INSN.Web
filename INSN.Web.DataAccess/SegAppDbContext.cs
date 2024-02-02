using INSN.Web.DataAccess.Acceso;
using INSN.Web.Entities.SegApp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace INSN.Web.DataAccess
{
    /// <summary>
    /// SegAppDbContext
    /// </summary>
    public class SegAppDbContext : IdentityDbContext<INSNIdentityUser>
    {
        /// <summary>
        /// Inicializar
        /// </summary>
        /// <param name="options"></param>
        public SegAppDbContext(DbContextOptions<SegAppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// INSNIdentityUsuarioRol
        /// </summary>
        public DbSet<INSNIdentityUsuarioRol> INSNIdentityUsuarioRol { get; set; }

        /// <summary>
        /// INSNIdentitySistema
        /// </summary>
        public DbSet<INSNIdentitySistema> INSNIdentitySistema { get; set; }

        /// <summary>
        /// Seccion
        /// </summary>
        public DbSet<Seccion> Seccion { get; set; }

        /// <summary>
        /// Modulo
        /// </summary>
        public DbSet<Modulo> Modulo { get; set; }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // AspNetUsers
            builder.Entity<INSNIdentityUser>(e =>
            {
                e.ToTable("Usuario");
            });

            // AspNetRoles
            builder.Entity<IdentityRole>(e =>
            {
                e.ToTable("Rol");
            });

            //AspNetUserRoles
            builder.Entity<INSNIdentityUsuarioRol>(e =>
            {
                e.ToTable("UsuarioRol");
                e.HasKey(ur => new { ur.CodigoUsuarioRolId });
                //e.HasKey(ur => new { ur.UserId, ur.RoleId, ur.CodigoSistemaId });
            });

            builder.Entity<INSNIdentitySistema>(e =>
            {
                e.ToTable("Sistema");
                e.HasKey(ur => new { ur.CodigoSistemaId });
            });

            // Tabla Seccion
            builder.Entity<Seccion>(e =>
            {
                e.ToTable("Seccion");
                e.HasKey(ur => new { ur.CodigoSeccionId });
            });

            // Tabla Modulo
            builder.Entity<Modulo>(e =>
            {
                e.ToTable("Modulo");
                e.HasKey(ur => new { ur.CodigoModuloId });
            });
        }
    }
}