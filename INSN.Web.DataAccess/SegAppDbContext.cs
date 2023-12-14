using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

            // AspNetUserRoles
            builder.Entity<IdentityUserRole<string>>(e =>
            {
                e.ToTable("UsuarioRol");
            });
        }
    }
}
