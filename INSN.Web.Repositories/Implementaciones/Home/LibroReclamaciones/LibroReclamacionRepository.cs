using INSN.Web.DataAccess;
using INSN.Web.Entities.Home.LibroReclamacion;
using INSN.Web.Repositories.Interfaces.Home.LibroReclamaciones;
using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// Libro Reclamacion Ruta Imagen Actualizar
        /// <param name="CodigoLibroReclamacionId"></param>
        /// <param name="RutaImagen"></param>
        /// </summary>
        public async Task LibroReclamacionRutaImagenActualizar(int CodigoLibroReclamacionId, string RutaImagen)
        {
            var libro = await Context.Set<LibroReclamacion>()
                                          .FirstOrDefaultAsync(c => c.CodigoLibroReclamacionId == CodigoLibroReclamacionId);

            if (libro != null)
            {
                libro.RutaImagen = RutaImagen;
                await Context.SaveChangesAsync();
            }
        }
    }
}