﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Models.Response.Sistema
{
    public class ModuloDtoResponse
    {
        /// <summary>
        /// Codigo Modulo Id
        /// </summary>
        public int CodigoModuloId { get; set; } = default!;

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; } = default!;

        /// <summary>
        /// Controlador
        /// </summary>
        public string Controlador { get; set; } = default!;

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; } = default!;

        /// <summary>
        /// Icono
        /// </summary>
        public string Icono { get; set; } = default!;
    }
}