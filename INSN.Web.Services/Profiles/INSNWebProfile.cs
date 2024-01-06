using AutoMapper;
using INSN.Web.Entities;
using INSN.Web.Entities.DocumentoLegal;
using INSN.Web.Entities.Info.Mantenimiento;
using INSN.Web.Entities.SegApp;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response.SegApp;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

            // Mapear Rol
            CreateMap<Rol, RolDtoResponse>();
            CreateMap<RolDtoRequest, Rol>();

            // Mapear Tipo Documento Identidad
            CreateMap<TipoDocumentoIdentidad, TipoDocumentoIdentidadDtoResponse>();
            CreateMap<TipoDocumentoIdentidadDtoRequest, TipoDocumentoIdentidad>();

            // Mapear Usuario
            CreateMap<Usuario, UsuarioDtoResponse>();
            CreateMap<UsuarioDtoRequest, Usuario>();
            CreateMap<UsuarioInfo, UsuarioDtoResponse>();

            // Mapear Usuario Rol
            CreateMap<UsuarioRol, UsuarioRolDtoResponse>();
            CreateMap<UsuarioRolDtoRequest, UsuarioRol>();
            CreateMap<UsuarioRolInfo, UsuarioRolDtoResponse>();
        }
    }
}
