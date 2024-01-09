using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Response.SegApp.Mantenimiento
{
    public class UsuarioDtoResponse : BaseResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nombres
        /// </summary>
        public string Nombres { get; set; } = default!;

        /// <summary>
        /// Apellido Paterno
        /// </summary>
        public string ApellidoPaterno { get; set; } = default!;

        /// <summary>
        /// Apellido Materno
        /// </summary>
        public string? ApellidoMaterno { get; set; }

        /// <summary>
        /// Servicio
        /// </summary>
        public string Servicio { get; set; } = default!;

        /// <summary>
        /// Telefono2
        /// </summary>
        public string? Telefono2 { get; set; }

        /// <summary>
        /// Abreviatura Tipo Documento Identidad
        /// </summary>
        public string AbreviaturaTipoDocumentoIdentidad { get; set; } = default!;

        /// <summary>
        /// TipoDocumentoIdentidadId
        /// </summary>
        public int TipoDocumentoIdentidadId { get; set; } = default!;

        /// <summary>
        /// Documento Identidad
        /// </summary>
        public string DocumentoIdentidad { get; set; } = default!;

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; } = default!;

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; } = default!;
    }
}
