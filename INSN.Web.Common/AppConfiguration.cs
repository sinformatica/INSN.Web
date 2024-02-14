#nullable disable
// La linea de arriba desactiva la comprobacion de nulos a nivel de archivo

namespace INSN.Web.Common
{
    /// <summary>
    /// AppConfiguration
    /// </summary>
    public class AppConfiguration
    {
        /// <summary>
        /// Variable Jwt
        /// </summary>
        public Jwt Jwt { get; set; }
    }

    /// <summary>
    /// Clase Jwt
    /// </summary>
    public class Jwt
    {
        /// <summary>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Audiencia
        /// </summary>
        public string Audiencia { get; set; }

        /// <summary>
        /// Emisor
        /// </summary>
        public string Emisor { get; set; }
    }
}