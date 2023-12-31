﻿namespace INSN.Web.Entities.Base
{
    /// <summary>
    /// Entidades Base - Reutilizables
    /// </summary>
    public class EntityBase
    {    
        /// <summary>
        /// Id del Registro
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Estado: A=Activo , I=Inactivo
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Estado Registro: 0=Eliminado, 1=Activo
        /// </summary>
        public int EstadoRegistro { get; set; }

        /// <summary>
        /// Fecha Creacion
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Usuario Creacion
        /// </summary>
        public string? UsuarioCreacion { get; set; }

        /// <summary>
        /// Terminal Creacion
        /// </summary>
        public string? TerminalCreacion { get; set; }

        /// <summary>
        /// Fecha Modificacion
        /// </summary>
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// Usuario Modificacion
        /// </summary>
        public string? UsuarioModificacion { get; set; }

        /// <summary>
        /// Terminal Modificacion
        /// </summary>
        public string? TerminalModificacion { get; set; }

        /// <summary>
        /// Al crear un Registro se utilizara los siguientes datos
        /// </summary>
        protected EntityBase()
        {
            Estado = "A";
            FechaCreacion = DateTime.Now;             
        }
    }
}