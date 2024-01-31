using INSN.Web.DataAccess;
using INSN.Web.Entities.Home.LibroReclamacion;
using INSN.Web.Repositories.Interfaces.Home.LibroReclamaciones;

namespace INSN.Web.Repositories.Implementaciones.Home.LibroReclamaciones
{
    /// <summary>
    /// Metodos de Libro Reclamacion 
    /// </summary>
    public class LibroReclamacionRepository : RepositoryBase<LibroReclamacion>, ILibroReclamacionRepository
    {
        /// <summary>
        /// INSNWebDBContext
        /// </summary>
        /// <param name="context"></param>
        public LibroReclamacionRepository(INSNWebDBContext context) : base(context)
        {
        }
    }
}