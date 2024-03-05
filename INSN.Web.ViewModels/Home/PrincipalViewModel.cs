using INSN.Web.Models.Response.Home.Anuncios;
using INSN.Web.Models.Response.Home.Comunicados;
using INSN.Web.Models.Response.Home.Noticias;
using System.ComponentModel.DataAnnotations;

namespace INSN.Web.ViewModels.Home
{
    /// <summary>
    /// Represencacion ViewModel : Principal
    /// </summary>
    public class PrincipalViewModel : BaseModel
    {
        /// <summary>
        /// Titulo
        /// </summary>
        [Display(Name = "Titulo")]
        public string? Titulo { get; set; } = default!;

        /// <summary>
        /// FechaExpiracion
        /// </summary>
        [Display(Name = "FechaExpiracion")]
        public DateTime FechaExpiracion { get; set; }


        #region[Listas]
        /// <summary>
        /// Lista de estados
        /// </summary>
        public ICollection<BaseModel> Estados { get; } = new List<BaseModel>()
        {
            new() { Codigo = "A", Nombre = "Activo" },
            new() { Codigo = "I", Nombre = "Inactivo" },
        };

        /// <summary>
        /// Lista de comunicados
        /// </summary>
        public ICollection<ComunicadoDtoResponse>? ComunicadoLista { get; set; }

        /// <summary>
        /// Lista de noticias
        /// </summary>
        public ICollection<NoticiaDtoResponse>? NoticiaLista { get; set; }

        /// <summary>
        /// Lista de anuncios
        /// </summary>
        public ICollection<AnuncioDtoResponse>? AnuncioLista { get; set; }
        #endregion
    }
}
