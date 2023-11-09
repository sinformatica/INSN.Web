using AutoMapper;
using INSN.Web.Entities.DocumentoLegal;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Response.Home;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace INSN.Web.Services.Profiles
{
    /// <summary>
    /// Clase Profile
    /// </summary>
    public class INSNWebProfile : Profile
    {
        /// <summary>
        /// Credor de AutoMapper - Map
        /// </summary>
        public INSNWebProfile()
        {
            // El AutoMapper solo mapea de izquierda a derecha
    
            CreateMap<TipoDocumento, TipoDocumentoDtoResponse>();
            CreateMap<DocumentoLegal, DocumentoLegalDtoResponse>();

            CreateMap<DocumentoLegalDtoRequest, DocumentoLegal>();
        }
    }
}
