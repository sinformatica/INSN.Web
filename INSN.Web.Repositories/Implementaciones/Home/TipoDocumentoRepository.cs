using INSN.Web.DataAccess;
using INSN.Web.Entities.DocumentoLegal;
using INSN.Web.Repositories.Interfaces.Home;

namespace INSN.Web.Repositories.Implementaciones.Home
{
    /// <summary>
    /// Metodos de TipoDocumento 
    /// </summary>
    public class TipoDocumentoRepository : RepositoryBase<TipoDocumento>, ITipoDocumentoRepository
    {
        public TipoDocumentoRepository(INSNWebDBContext context) : base(context)
        {

        }
    }
}
