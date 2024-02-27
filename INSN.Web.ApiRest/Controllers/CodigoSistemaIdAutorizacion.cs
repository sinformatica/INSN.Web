using INSN.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace INSN.Web.ApiRest.Controllers
{
    /// <summary>
    /// CodigoSistemaIdAutorizacion
    /// </summary>
    public class CodigoSistemaIdAutorizacion : IAsyncAuthorizationFilter
    {
        private readonly string? codigoSistemaIdClaimValue;

        /// <summary>
        /// Instanciar
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public CodigoSistemaIdAutorizacion(IHttpContextAccessor httpContextAccessor)
        {
            codigoSistemaIdClaimValue = httpContextAccessor.HttpContext?.User?
                .Claims.FirstOrDefault(c => c.Type == "CodigoSistemaId")?.Value;
        }

        /// <summary>
        /// OnAuthorizationAsync
        /// </summary>
        /// <param name="context"></param>
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // Valida el claim "CodigoSistemaId" según tus requisitos
            if (codigoSistemaIdClaimValue != Constantes.CodigoSistemaIdFijo)
            {
                // No tiene el CodigoSistemaId permitido, establece el resultado de autorización a No Autorizado
                context.Result = new UnauthorizedResult();
            }

            return Task.CompletedTask;
        }
    }
}