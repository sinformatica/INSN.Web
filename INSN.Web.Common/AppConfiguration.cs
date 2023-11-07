#nullable disable
// La linea de arriba desactiva la comprobacion de nulos a nivel de archivo

namespace INSN.Web.Common
{
    /// <summary>
    /// Token
    /// </summary>
    public class AppConfiguration
    {
        public Jwt Jwt { get; set; }  
    }

    /// <summary>
    /// Token
    /// </summary>
    public class Jwt
    {
        public string SecretKey { get; set; }
        public string Audiencia { get; set; }
        public string Emisor { get; set; }
    }        
}
