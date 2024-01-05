using AutoMapper;
using INSN.Web.Entities;
using INSN.Web.Entities.DocumentoLegal;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
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

            // Mapear rol
            CreateMap<Rol, RolDtoResponse>();
            CreateMap<RolDtoRequest, Rol>();
        }
    }
}
