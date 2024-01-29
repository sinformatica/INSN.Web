using INSN.Web.Portal.Controllers.Home;
using INSN.Web.Portal.Services.Interfaces.Mantenimiento.Comunicados;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Mantenimiento.Comunicados
{
    public class ComunicadoController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly IComunicadoProxy _proxy;
        private readonly ILogger<POAController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        /// <param name="proxy"></param>
        public ComunicadoController(ILogger<POAController> logger, IWebHostEnvironment env,  IComunicadoProxy proxy)
        {
            _proxy = proxy;
            _logger = logger;
            _enviroment = env;
        }
    }
}
