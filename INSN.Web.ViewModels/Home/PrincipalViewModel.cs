﻿using INSN.Web.Models.Response.Mantenimiento.Comunicados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion
    }
}