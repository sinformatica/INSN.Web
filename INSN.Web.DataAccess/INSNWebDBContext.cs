using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Se va agregar la configuracion de las entidades desde este mismo ensamblado
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}