﻿using INSN.Web.Models.Response.SegApp.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace INSN.Web.ViewModels.SegApp.Mantenimiento
{
    /// <summary>
    /// Represencacion ViewModel : Rol
    /// </summary>
    public class RolViewModel : BaseModel
    {
        /// <summary>
        /// Lista de Rol
        /// </summary>       
        public ICollection<RolDtoResponse>? Roles { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [Display(Name = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Display(Name = "Name")]
        public string? Name { get; set; } = default!;

        public ICollection<BaseModel> Estados { get; } = new List<BaseModel>()
        {
            new() { Codigo = "A", Nombre = "Activo" },
            new() { Codigo = "I", Nombre = "Inactivo" },
        };
    }
}