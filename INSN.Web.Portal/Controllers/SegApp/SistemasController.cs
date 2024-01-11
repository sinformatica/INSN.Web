using INSN.Web.Common;
using INSN.Web.Models;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Portal.Services.Interfaces.SegApp;
using INSN.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

namespace INSN.Web.Portal.Controllers.SegApp
{
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
