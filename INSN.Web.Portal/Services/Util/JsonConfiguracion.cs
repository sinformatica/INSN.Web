namespace INSN.Web.Portal.Services.Util
{
    /// <summary>
    /// Json Configuracion
    /// </summary>
    public static class JsonConfiguracion
    {
        private static readonly IConfiguration _configuration;

        /// <summary>
        /// Ruta Directorio Padre
        /// </summary>
        public static string? RutaDirectorioPadre { get; }

        /// <summary>
        /// Inicializar
        /// </summary>
        static JsonConfiguracion()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.Development.json") // cambiar en producción
                .Build();

            RutaDirectorioPadre = _configuration.GetValue<string>("FileServer:RutaDirectorioPadre");
        }
    }
}