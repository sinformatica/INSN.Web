using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.ApiRest.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeByCodigoSistemaIdAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _codigoSistemaId;

        public AuthorizeByCodigoSistemaIdAttribute(string codigoSistemaId)
        {
            _codigoSistemaId = codigoSistemaId;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user.Identity.IsAuthenticated)
            {
                // Obtener el valor del CodigoSistemaId desde la variable fija
                string sistemaIdFijo = "1";

                if (!string.Equals(_codigoSistemaId, sistemaIdFijo, StringComparison.OrdinalIgnoreCase))
                {
                    context.Result = new ForbidResult();
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
