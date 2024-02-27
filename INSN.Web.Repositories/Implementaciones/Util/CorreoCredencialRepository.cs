using INSN.Web.DataAccess;
using INSN.Web.Entities.Util;
using INSN.Web.Repositories.Interfaces.Util;

namespace INSN.Web.Repositories.Implementaciones.Util
{
    /// <summary>
    /// Correo Credencial Repository
    /// </summary>
    public class CorreoCredencialRepository : RepositoryBase<CorreoCredencial>, ICorreoCredencialRepository
    {
        /// <summary>
        /// Instanciar
        /// <param name="context"></param>
        /// </summary>
        public CorreoCredencialRepository(INSNWebDBContext context) : base(context)
        {
        }
    }
}