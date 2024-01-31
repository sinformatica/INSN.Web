using INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.SegApp.Mantenimiento
{
    /// <summary>
    /// Controlador Usuario Rol
    /// </summary>
    public class UsuarioRolController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly IUsuarioRolProxy _proxy;
        private readonly ILogger<UsuarioRolController> _logger;

        /// <summary>
        /// UsuarioRolController
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public UsuarioRolController(IUsuarioRolProxy proxy,
                        ILogger<UsuarioRolController> logger,
                        IWebHostEnvironment env)
        {
            _proxy = proxy;
            _logger = logger;
            _enviroment = env;
        }
    }
}
