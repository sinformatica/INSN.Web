namespace INSN.Web.ViewModels.Common.Constantes
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
        /// Constantes Tipo Convocatoria Id
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
    }
}