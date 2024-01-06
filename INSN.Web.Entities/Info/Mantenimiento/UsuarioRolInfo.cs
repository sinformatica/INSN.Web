using INSN.Web.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Entities.Info.Mantenimiento
{
    public class UsuarioRolInfo : AuditoriaBase
    {
        /// <summary>
        /// Nombre Rol
        /// </summary>
        public string NombreRol { get; set; }

        /// <summary>
        /// Role Id
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Nombre Sistema
        /// </summary>
        public string NombreSistema { get; set; }

        /// <summary>
        /// Codigo Sistema Id
        /// </summary>
        public int CodigoSistemaId { get; set; }
    }
}
