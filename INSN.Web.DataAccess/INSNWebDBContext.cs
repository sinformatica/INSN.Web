﻿using INSN.Web.Entities.SegApp;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using INSN.Web.Entities.Home.LibroReclamacion;

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
        public INSNWebDBContext(DbContextOptions<INSNWebDBContext> options)
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
            #region [SegApp]
            modelBuilder.Entity<Rol>().HasKey(f => f.Id);
            modelBuilder.Entity<Usuario>().HasKey(f => f.Id);
            modelBuilder.Entity<Sistema>().HasKey(f => f.CodigoSistemaId);
            modelBuilder.Entity<UsuarioRol>().HasKey(f => f.CodigoUsuarioRolId);
            #endregion

            #region [LibroReclamacion]
            modelBuilder.Entity<LibroReclamacion>().HasKey(f => f.CodigoLibroReclamacionId);
            #endregion
            #endregion

            //Se va agregar la configuracion de las entidades desde este mismo ensamblado
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}