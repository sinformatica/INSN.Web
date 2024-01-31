using INSN.Web.Entities.Base;

namespace INSN.Web.Entities.Home.LibroReclamacion
{
    /// <summary>
    /// Entidad Logica : Libro Reclamacion
    /// </summary>
    public class LibroReclamacion : AuditoriaBase
    {
        /// <summary>
        /// Tipo Persona
        /// </summary>
        public string? TipoPersona { get; set; } = default!;

        /// <summary>
        /// Codigo Libro Reclamacion Id
        /// </summary>
        public int CodigoLibroReclamacionId { get; set; }

        /// <summary>
        /// Tipo Documento Identidad
        /// </summary>
        public string? TipoDocumentoIdentidad { get; set; } = default!;

        /// <summary>
        /// Documento Identidad
        /// </summary>
        public string? DocumentoIdentidad { get; set; } = default!;

        /// <summary>
        /// RUC
        /// </summary>
        public string? RUC { get; set; } = default!;

        /// <summary>
        /// Razon Social
        /// </summary>
        public string? RazonSocial { get; set; } = default!;

        /// <summary>
        /// Nombres
        /// </summary>
        public string? Nombres { get; set; } = default!;

        /// <summary>
        /// Apellido Paterno
        /// </summary>
        public string? ApellidoPaterno { get; set; } = default!;

        /// <summary>
        /// Apellido Materno
        /// </summary>
        public string? ApellidoMaterno { get; set; } = default!;

        /// <summary>
        /// Direccion
        /// </summary>
        public string? Direccion { get; set; } = default!;

        /// <summary>
        /// Celular Teléfono
        /// </summary>
        public string? CelularTelefono { get; set; } = default!;

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; } = default!;

        /// <summary>
        /// Reclamo
        /// </summary>
        public string? Reclamo { get; set; } = default!;

        /// <summary>
        /// Tipo Parentesco
        /// </summary>
        public string? TipoParentesco { get; set; } = default!;

        /// <summary>
        /// Tipo Documento Identidad Paciente
        /// </summary>
        public string? TipoDocumentoIdentidadPaciente { get; set; } = default!;

        /// <summary>
        /// Documento Identidad Paciente
        /// </summary>
        public string? DocumentoIdentidadPaciente { get; set; } = default!;

        /// <summary>
        /// Nombre Paciente
        /// </summary>
        public string? NombrePaciente { get; set; } = default!;

        /// <summary>
        /// Apellido Paterno Paciente
        /// </summary>
        public string? ApellidoPaternoPaciente { get; set; } = default!;

        /// <summary>
        /// Apellido Materno Paciente
        /// </summary>
        public string? ApellidoMaternoPaciente { get; set; } = default!;

        /// <summary>
        /// Autorizacion
        /// </summary>
        public bool Autorizacion { get; set; }
    }
}