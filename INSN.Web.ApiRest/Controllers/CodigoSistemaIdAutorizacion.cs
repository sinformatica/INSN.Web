using INSN.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace INSN.Web.ApiRest.Controllers
{
    public class CodigoSistemaIdAutorizacion : IAsyncAuthorizationFilter
    {
        private readonly string codigoSistemaIdClaimValue;

        public CodigoSistemaIdAutorizacion(IHttpContextAccessor httpContextAccessor)
        {
            // Accede al claim "CodigoSistemaId" en el constructor del filtro
            codigoSistemaIdClaimValue = httpContextAccessor.HttpContext?.User?
                .Claims.FirstOrDefault(c => c.Type == "CodigoSistemaId")?.Value;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // Valida el claim "CodigoSistemaId" según tus requisitos
            if (codigoSistemaIdClaimValue != Constantes.CodigoSistemaIdFijo)
            {
                // No tiene el CodigoSistemaId permitido, establece el resultado de autorización a No Autorizado
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
