using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento;
using INSN.Web.ViewModels.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.SegApp.Mantenimiento
{
    public class UsuarioRolController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly IUsuarioRolProxy _proxy;
        private readonly ILogger<UsuarioRolController> _logger;

        /// <summary>
        /// 
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

        /// <summary>
        /// Rol Listar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
    }
}
