using INSN.Web.Common;
using INSN.Web.Models.Request.Home.Anuncios;
using INSN.Web.Models.Request.Home.Comunicados;
using INSN.Web.Models.Request.Home.Noticias;
using INSN.Web.Models.Response.Home.Anuncios;
using INSN.Web.Models.Response.Home.Comunicados;
using INSN.Web.Models.Response.Home.Noticias;
using INSN.Web.Portal.Models;
using INSN.Web.Portal.Services.Interfaces.Home.Anuncios;
using INSN.Web.Portal.Services.Interfaces.Home.Comunicados;
using INSN.Web.Portal.Services.Interfaces.Home.Noticias;
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
        private readonly INoticiaProxy _proxyNoticia;
        private readonly IAnuncioProxy _proxyAnuncio;

        /// <summary>
        /// Home Controller
        /// </summary>
        /// <param name="proxyComunicado"></param>
        /// <param name="proxyNoticia"></param>
        /// <param name="proxyAnuncio"></param>
        public HomeController(IComunicadoProxy proxyComunicado, INoticiaProxy proxyNoticia, IAnuncioProxy proxyAnuncio)
        {
            _proxyComunicado = proxyComunicado;
            _proxyNoticia = proxyNoticia;
            _proxyAnuncio = proxyAnuncio;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            PrincipalViewModel model = new PrincipalViewModel();

            #region[Comunicado]
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
            #endregion

            #region[Noticia]
            var resultNoticias = NoticiaListar();
            model.NoticiaLista = resultNoticias.Result;

            foreach (var item in model.NoticiaLista)
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

                // Listar detalle Noticia
                var resultDetalle = _proxyNoticia.NoticiaDetalleListar(item.CodigoNoticiaId);
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
            #endregion

            #region[Anuncio]
            var resultAnuncios = AnuncioListar();
            model.AnuncioLista = resultAnuncios.Result;

            foreach (var item in model.AnuncioLista)
            {
                if (item.RutaImagen != null)
                {
                    item.Extension = item.Extension;
                    item.ImagenBytes = System.IO.File.ReadAllBytes(item.RutaImagen);
                }
            }
            #endregion

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

        #region[Noticia]
        /// <summary>
        /// Noticia Listar
        /// </summary>  
        /// <returns></returns>
        public async Task<List<NoticiaDtoResponse>> NoticiaListar()
        {
            var result = await _proxyNoticia.NoticiaListar(new NoticiaDtoRequest()
            {
                Titulo = "",
                FechaExpiracion = DateTime.Now,
                Estado = Enumerado.Estado.Activo,
                EstadoRegistro = Enumerado.EstadoRegistro.Activo
            });

            return (List<NoticiaDtoResponse>)result;
        }
        #endregion

        #region[Anuncio]
        /// <summary>
        /// Anuncio Listar
        /// </summary>  
        /// <returns></returns>
        public async Task<List<AnuncioDtoResponse>> AnuncioListar()
        {
            var result = await _proxyAnuncio.AnuncioListar(new AnuncioDtoRequest()
            {
                NombreReferencial = "",
                FechaExpiracion = DateTime.Now,
                Estado = Enumerado.Estado.Activo,
                EstadoRegistro = Enumerado.EstadoRegistro.Activo
            });

            return (List<AnuncioDtoResponse>)result;
        }
        #endregion
    }
}