namespace INSN.Web.Portal.Services.Util
{
    /// <summary>
    /// Carpeta Helper
    /// </summary>
    public static class CarpetaHelper
    {
        /// <summary>
        /// Crear Carpeta
        /// <param name="raiz"></param>
        /// <param name="nombreCarpeta"></param>
        /// </summary>
        public static bool CrearCarpeta(string raiz, string nombreCarpeta)
        {
            bool rpta;
            string? RutaDirectorioPadre = JsonConfiguracion.RutaDirectorioPadre;
            string directorio = RutaDirectorioPadre + raiz;

            string rutaCarpeta = Path.Combine(directorio, nombreCarpeta);

            try
            {
                // Verificar si el directorio padre existe
                if (!Directory.Exists(directorio))
                {
                    throw new DirectoryNotFoundException("El directorio padre no existe.");
                }

                // Verificar si la carpeta ya existe
                if (Directory.Exists(rutaCarpeta))
                {
                    throw new IOException("La carpeta ya existe.");
                }

                // Crear la carpeta
                Directory.CreateDirectory(rutaCarpeta);
                rpta = true;
            }
            catch (Exception ex)
            {
                throw new IOException($"Error al crear la carpeta: {ex.Message}");
            }

            return rpta;
        }

        /// <summary>
        /// Guardar Archivo
        /// <param name="raiz"></param>
        /// <param name="carpeta"></param>
        /// <param name="nombre"></param>
        /// <param name="archivo"></param>
        /// </summary>
        public static async Task<string> GuardarArchivo(string raiz, string carpeta, string nombre, IFormFile archivo)
        {
            try
            {
                // capturar nombre actual del archivo
                string NombreActualArchivo = Path.GetFileName(archivo.FileName);

                // capturar la extensión del archivo
                string Extension = Path.GetExtension(NombreActualArchivo);

                // concatenar nombre con la extesión
                string NombreArchivo = nombre + Extension;

                // armar la ruta donde se guardará el archivo
                string? RutaDirectorioPadre = JsonConfiguracion.RutaDirectorioPadre;
                string RutaServidorExterno = RutaDirectorioPadre + raiz + (!string.IsNullOrEmpty(carpeta) ? "\\" + carpeta : "") + "\\" + NombreArchivo;

                using (var stream = new FileStream(RutaServidorExterno, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }

                return RutaServidorExterno;
            }
            catch (Exception ex)
            {
                throw new IOException($"Error al guardar archivo: {ex.Message}");
            }
        }

        /// <summary>
        /// Validar Archivo
        /// <param name="tipo"></param>
        /// <param name="PesoMaximoMb"></param>
        /// <param name="archivo"></param>
        /// </summary>
        public static void ValidarArchivo(string tipo, int PesoMaximoMb, IFormFile archivo)
        {
            try
            {
                // Obtener las extensiones permitidas para el tipo especificado
                if (!TiposPermitidos.ContainsKey(tipo))
                {
                    throw new ArgumentException($"Tipo de archivo no válido: {tipo}");
                }

                var ExtensionesPermitidas = TiposPermitidos[tipo];
                string NombreActualArchivo = Path.GetFileName(archivo.FileName);
                string Extension = Path.GetExtension(NombreActualArchivo);

                // Validar si la extensión del archivo subido está en la lista de extensiones permitidas
                if (!ExtensionesPermitidas.Contains(Extension, StringComparer.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException($"El tipo de archivo no es válido para el tipo {tipo}. Se esperaba: {string.Join(", ", ExtensionesPermitidas)}");
                }
                else
                {
                    long PesoMaxBytes = PesoMaximoMb * 1024 * 1024; // Convertir a bytes

                    if (archivo.Length > PesoMaxBytes)
                    {
                        throw new ArgumentException($"El archivo pesa más de lo permitido. Tamaño máximo: {PesoMaximoMb}Mb.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Error al guardar archivo: {ex.Message}");
            }
        }

        /// <summary>
        /// Tipos Permitidos
        /// </summary>
        private static readonly Dictionary<string, string[]> TiposPermitidos = new Dictionary<string, string[]>
        {
            { "imagen", new string[] { ".jpg", ".jpeg", ".png" } },
            { "pdf", new string[] { ".pdf" } },
            { "excel", new string[] { ".xls", ".xlsx" } },
        };
    }
}