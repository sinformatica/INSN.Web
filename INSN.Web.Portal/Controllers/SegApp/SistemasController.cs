using INSN.Web.Portal.Services.Interfaces.SegApp;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.SegApp
{
    /// <summary>
    /// Controlador SistemasController
    /// </summary>
    public class SistemasController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly ISistemaProxy _proxy;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Sistemas Controller
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public SistemasController(ISistemaProxy proxy, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _proxy = proxy;
            _enviroment = env;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}