namespace INSN.Web.Common
{
    /// <summary>
    /// Variables - Constantes - Enumerado - FrontEnd
    /// </summary>
    public class Enumerado
    {
        /// <summary>
        /// Constantes Tipo Convocatoria Id
        /// </summary>
        public struct TipoConvocatoriaId
        {
            /// <summary>
            /// Id Cas
            /// </summary>
            public const int Cas = 1;

            /// <summary>
            /// Id Interno
            /// </summary>
            public const int Interno = 2;

            /// <summary>
            /// Id Público
            /// </summary>
            public const int Público = 3;

            /// <summary>
            /// Id Suplencias
            /// </summary>
            public const int Suplencias = 4;

            /// <summary>
            /// Id Nombramiento
            /// </summary>
            public const int Nombramiento = 5;

            /// <summary>
            /// Id Reasignación
            /// </summary>
            public const int Reasignación = 6;
        }

        /// <summary>
        /// Constantes Estado Convocatoria
        /// </summary>
        public struct EstadoConvocatoria
        {
            /// <summary>
            /// En Proceso
            /// </summary>
            public const string EnProceso = "E";

            /// <summary>
            /// Concluido
            /// </summary>
            public const string Concluido = "C";
        }

        /// <summary>
        /// Constantes Estado
        /// </summary>
        public struct Estado
        {
            /// <summary>
            /// Activo
            /// </summary>
            public const string Activo = "A";

            /// <summary>
            /// Inactivo
            /// </summary>
            public const string Inactivo = "I";
        }

        /// <summary>
        /// Constantes Estado
        /// </summary>
        public struct EstadoRegistro
        {
            /// <summary>
            /// Activo
            /// </summary>
            public const int Activo = 1;

            /// <summary>
            /// Inactivo
            /// </summary>
            public const int Inactivo = 0;

        }

        /// <summary>
        /// Constantes Documento Legal
        /// </summary>
        public struct DocumentoLegal
        {
            /// <summary>
            /// Normas Emitidas
            /// </summary>
            public const string NormasEmitidas = "DOCUMENTO LEGAL";

            /// <summary>
            /// PROA
            /// </summary>
            public const string PROA = "PROA";

            /// <summary>
            /// SST
            /// </summary>
            public const string SST = "SST";

            /// <summary>
            /// SCI
            /// </summary>
            public const string SCI = "SCI";

            /// <summary>
            /// UFGRD
            /// </summary>
            public const string UFGRD = "UFGRD";

            /// <summary>
            /// Covid19
            /// </summary>
            public const string Covid19 = "COVID19";

            /// <summary>
            /// Planeamiento Organizacion
            /// </summary>
            public const string PlaneamientoOrganizacion = "PLANEAMIENTO ORGANIZACION";

            /// <summary>
            /// Presupuesto
            /// </summary>
            public const string Presupuesto = "PRESUPUESTO";

            /// <summary>
            /// Proyecto Inversion Infobras
            /// </summary>
            public const string ProyectoInversionInfobras = "PROYECTO INVERSION INFOBRAS";

            /// <summary>
            /// Personal
            /// </summary>
            public const string Personal = "PERSONAL";

            /// <summary>
            /// Contratacion Bienes Servicios
            /// </summary>
            public const string ContratacionBienesServicios = "CONTRATACION BIENES SERVICIOS";

            /// <summary>
            /// Actividad Oficial
            /// </summary>
            public const string ActividadOficial = "ACTIVIDAD OFICIAL";

            /// <summary>
            /// Acceso Informacion
            /// </summary>
            public const string AccesoInformacion = "ACCESO INFORMACION";

            /// <summary>
            /// Registro Visitas
            /// </summary>
            public const string RegistroVisitas = "REGISTRO VISITAS";

            /// <summary>
            /// Participacion Ciudadana
            /// </summary>
            public const string ParticipacionCiudadana = "PARTICIPACION CIUDADANA";

            /// <summary>
            /// TeleSalud
            /// </summary>
            public const string TeleSalud = "TELESALUD";

            /// <summary>
            /// SUBCAFAE
            /// </summary>
            public const string SUBCAFAE = "SUBCAFAE";
        }
    }
}