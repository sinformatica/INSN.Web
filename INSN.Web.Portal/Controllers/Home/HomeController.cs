using INSN.Web.Common;
using INSN.Web.Models.Request.Home.Comunicados;
using INSN.Web.Models.Response.Home.Comunicados;
using INSN.Web.Portal.Models;
using INSN.Web.Portal.Services.Interfaces.Home.Comunicados;
using INSN.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace INSN.Web.Portal.Controllers.Home
{
    /// <summary>
    /// Controlador Home
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IComunicadoProxy _proxyComunicado;

        /// <summary>
        /// Home Controller
        /// </summary>
        /// <param name="proxyComunicado"></param>
        public HomeController(IComunicadoProxy proxyComunicado)
        {
            _proxyComunicado = proxyComunicado;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            PrincipalViewModel model = new PrincipalViewModel();
            var resultComunicados = ComunicadoListar();
            model.ComunicadoLista = resultComunicados.Result;

            foreach (var item in model.ComunicadoLista)
            {
                if (item.RutaImagenPortada != null)
                {
                    // Obtener la extensión
                    string? extension = Path.GetExtension(item.RutaImagenPortada);
                    if (extension != null)
                    {
                        item.Extension = extension.TrimStart('.').ToLower();

                        // Leer la imagen y convertirla en un arreglo de bytes
                        item.ImagenBytes = System.IO.File.ReadAllBytes(item.RutaImagenPortada);
                    }
                }

                // Listar detalle comunicado
                var resultDetalle = _proxyComunicado.ComunicadoDetalleListar(item.CodigoComunicadoId);
                item.DetalleLista = resultDetalle.Result;

                foreach (var det in item.DetalleLista)
                {
                    if (det.RutaImagen != null)
                    {
                        // Obtener la extensión
                        string? extension = Path.GetExtension(det.RutaImagen);
                        if (extension != null)
                        {
                            det.Extension = extension.TrimStart('.').ToLower();

                            // Leer la imagen y convertirla en un arreglo de bytes
                            det.ImagenBytes = System.IO.File.ReadAllBytes(det.RutaImagen);
                        }
                    }
                }
            }

            return View("~/Views/Home/Index.cshtml", model);
        }

        /// <summary>
        /// Nosotros
        /// </summary>
        /// <returns></returns>
        public IActionResult Nosotros()
        {
            return View();
        }

        /// <summary>
        /// Contacto
        /// </summary>
        /// <returns></returns>
        public IActionResult Contacto()
        {
            return View();
        }

        /// <summary>
        /// Especialidades
        /// </summary>
        /// <returns></returns>
        public IActionResult Especialidades()
        {
            return View();
        }

        /// <summary>
        /// Privacy
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region[Comunicado]
        /// <summary>
        /// Comunicado Listar
        /// </summary>  
        /// <returns></returns>
        public async Task<List<ComunicadoDtoResponse>> ComunicadoListar()
        {
            var result = await _proxyComunicado.ComunicadoListar(new ComunicadoDtoRequest()
            {
                Titulo = "",
                FechaExpiracion = DateTime.Now,
                Estado = Enumerado.Estado.Activo,
                EstadoRegistro = Enumerado.EstadoRegistro.Activo
            });

            return (List<ComunicadoDtoResponse>)result;
        }
        #endregion
    }
}