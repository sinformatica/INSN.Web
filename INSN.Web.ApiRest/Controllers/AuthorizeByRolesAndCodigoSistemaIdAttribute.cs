using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using INSN.Web.Common;

namespace INSN.Web.ApiRest.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeByRolesAndCodigoSistemaIdAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string[] _roles;
        private readonly string _codigoSistemaId;

        public AuthorizeByRolesAndCodigoSistemaIdAttribute(string codigoSistemaId, params string[] roles)
        {
            _codigoSistemaId = codigoSistemaId;
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user.Identity.IsAuthenticated)
            {
                // Verificar roles
                var userRoles = ((ClaimsIdentity)user.Identity).Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();

                bool rolesMatched = _roles.Any(role => userRoles.Contains(role));

                // Obtener el valor del CodigoSistemaId desde la variable fija
                string sistemaIdFijo = Constantes.CodigoSistemaIdFijo;

                bool codigoSistemaIdMatched = string.Equals(_codigoSistemaId, sistemaIdFijo, StringComparison.OrdinalIgnoreCase);

                if (!(rolesMatched && codigoSistemaIdMatched))
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
