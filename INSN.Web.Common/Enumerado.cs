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
        /// Constantes Documentos Legales
        /// </summary>
        public struct DocumentosLegales
        {
            /// <summary>
            /// COVID19
            /// </summary>
            public const string Covid19 = "COVID19";

            /// <summary>
            /// POA
            /// </summary>
            public const string PROA = "PROA";

            /// <summary>
            /// SST
            /// </summary>
            public const string SST = "SST";

            /// <summary>
            /// Documento Legal
            /// </summary>
            public const string DocumentoLegal = "DOCUMENTOLEGAL";

            /// <summary>
            /// Informe Gestion
            /// </summary>
            public const string TeleSalud = "TELESALUD";

            /// <summary>
            /// SCI
            /// </summary>
            public const string SCI = "SCI";

            /// <summary>
            /// SUBCAFAE
            /// </summary>
            public const string SUBCAFAE = "SUBCAFAE";

            /// <summary>
            /// UFGRD
            /// </summary>
            public const string UFGRD = "UFGRD";
        }
    }
}