using INSN.Web.DataAccess.Acceso;
using INSN.Web.Entities.SegApp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.DataAccess
{
    public class SegAppDbContext : IdentityDbContext<INSNIdentityUser>
    {
        public SegAppDbContext(DbContextOptions<SegAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<INSNIdentityUsuarioRol> INSNIdentityUsuarioRol { get; set; }
        public DbSet<INSNIdentitySistema> INSNIdentitySistema { get; set; }
        public DbSet<Seccion> Seccion { get; set; }
        public DbSet<Modulo> Modulo { get; set; }

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
