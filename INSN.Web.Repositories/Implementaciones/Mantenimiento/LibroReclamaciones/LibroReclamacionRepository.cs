using INSN.Web.DataAccess;
using INSN.Web.Entities.Mantenimiento.LibroReclamacion;
using INSN.Web.Repositories.Interfaces.Mantenimiento.LibroReclamaciones;

namespace INSN.Web.Repositories.Implementaciones.Mantenimiento.LibroReclamaciones
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