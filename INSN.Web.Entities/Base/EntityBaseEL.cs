namespace INSN.Web.Entities.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityBaseEL
    {    

        /// <summary>
        /// 
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? UsuarioCreacion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? TerminalCreacion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? UsuarioModificacion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? TerminalModificacion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected EntityBaseEL()
        {
            Estado = true;
            FechaCreacion = DateTime.Now;
            UsuarioModificacion = "";
            TerminalModificacion = "";        
        }
    }
}