using INSN.Web.Common;
using INSN.Web.Models.Request.Mantenimiento.Comunicados;
using INSN.Web.Portal.Controllers.Home;
using INSN.Web.Portal.Services.Interfaces.Mantenimiento.Comunicados;
using INSN.Web.ViewModels.Mantenimiento.Comunicados;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Mantenimiento.Comunicados
{
    public class ComunicadoController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly ILogger<POAController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IComunicadoProxy _proxy;
        private readonly string CodigoSistemaIdUsuario;
        private readonly string NombreRolUsuario;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        /// <param name="proxy"></param>
        public ComunicadoController(ILogger<POAController> logger, IWebHostEnvironment env,  IComunicadoProxy proxy,
                IHttpContextAccessor httpContextAccessor)
        {
            _proxy = proxy;
            _logger = logger;
            _enviroment = env;
            _httpContextAccessor = httpContextAccessor;

            CodigoSistemaIdUsuario = _httpContextAccessor.HttpContext.Session.GetString(Constantes.CodigoSistemaIdUsuario);
            NombreRolUsuario = _httpContextAccessor.HttpContext.Session.GetString(Constantes.NombreRolUsuario);
        }

        private bool ValidarSistema()
        {
            return CodigoSistemaIdUsuario == Constantes.CodigoSistemaIdFijo;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(ComunicadoViewModel model)
        {
            bool b = false;

            if (ValidarSistema())
            {
                if (NombreRolUsuario == Constantes.RolAdminSistemas) b = true;
            }

            if (b)
                return await ComunicadoListar(model);
            else
                return RedirectToAction("AccesoDenegado", "Acceso");
        }

        #region[Comunicado]
        /// <summary>
        /// Comunicado Listar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> ComunicadoListar(ComunicadoViewModel model)
        {
            try
            {
                var response = await _proxy.ComunicadoListar(new ComunicadoDtoRequest()
                {
                    Titulo = model.Titulo,
                    Estado = model.EstadoSeleccionado,
                    EstadoRegistro = 1
                });

                model.ComunicadoLista = response;
                return View("~/Views/Mantenimiento/Comunicados/Index.cshtml", model);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }
        #endregion
    }
}
