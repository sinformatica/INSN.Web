using INSN.Web.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Entities.SegApp
{
    public class UsuarioInfo : AuditoriaBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nombres
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Apellido Paterno
        /// </summary>
        public string ApellidoPaterno { get; set; }

        /// <summary>
        /// Apellido Materno
        /// </summary>
        public string? ApellidoMaterno { get; set; }

        /// <summary>
        /// servicio
        /// </summary>
        public string Servicio { get; set; }

        /// <summary>
        /// Telefono2
        /// </summary>
        public string? Telefono2 { get; set; }

        /// <summary>
        /// Abreviatura Tipo Documento Identidad
        /// </summary>
        public string AbreviaturaTipoDocumentoIdentidad { get; set; }

        /// <summary>
        /// TipoDocumentoIdentidadId
        /// </summary>
        public int TipoDocumentoIdentidadId { get; set; }

        /// <summary>
        /// Documento Identidad
        /// </summary>
        public string DocumentoIdentidad { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// NormalizedUserName
        /// </summary>
        public string NormalizedUserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// NormalizedEmail
        /// </summary>
        public string NormalizedEmail { get; set; }

        /// <summary>
        /// PasswordHash
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
