using AutoMapper;
using INSN.Web.Entities.Home.DocumentoInstitucional;
using INSN.Web.Entities.Home.LibroReclamacion;
using INSN.Web.Entities.Home.OportunidadLaboral;
using INSN.Web.Entities.Info.Home.OportunidadLaboral;
using INSN.Web.Entities.Info.Mantenimiento;
using INSN.Web.Entities.SegApp;
using INSN.Web.Models.Request.Home;
using INSN.Web.Models.Request.Home.DocumentoLegal;
using INSN.Web.Models.Request.Home.LibroReclamaciones;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.Home.DocumentoLegal;
using INSN.Web.Models.Response.Home.LibroReclamaciones;
using INSN.Web.Models.Response.Home.OportunidadLaboral;
using INSN.Web.Models.Response.SegApp;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response.Sistemas;

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
            CreateMap<TipoDocumentoDtoRequest, TipoDocumento>();

            CreateMap<DocumentoLegal, DocumentoLegalDtoResponse>();
            CreateMap<DocumentoLegalDtoRequest, DocumentoLegal>();

            //Mapear Convocatoria
            CreateMap<DocumentoConvocatoria, ConvocatoriaDtoResponse>();
            CreateMap<ConvocatoriaDtoRequest, Convocatoria>();

            CreateMap<DocumentoConvocatoriaInfo, ConvocatoriaDtoResponse>();

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

            // Mapear Sistema
            CreateMap<Sistema, SistemaDtoResponse>();

            // Mapear Libro Reclamacion
            CreateMap<LibroReclamacion, LibroReclamacionDtoResponse>();
            CreateMap<LibroReclamacionDtoRequest, LibroReclamacion>();
        }
    }
}