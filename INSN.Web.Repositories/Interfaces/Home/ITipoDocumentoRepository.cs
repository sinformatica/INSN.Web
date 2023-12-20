using INSN.Web.Entities.DocumentoLegal;

namespace INSN.Web.Repositories.Interfaces.Home
{
    /// <summary>
    /// Intarface de Metodos Tipo Documento
    /// </summary>
    public interface ITipoDocumentoRepository : IRepositoryBase<TipoDocumento>
    {
        /// <summary>
        /// Repository: TipoDocumento Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ICollection<TipoDocumento>> ListAsync(string Area, string Estado, int EstadoRegistro);
    }   
}