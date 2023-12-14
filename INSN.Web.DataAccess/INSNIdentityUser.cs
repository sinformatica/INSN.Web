﻿using INSN.Web.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.DataAccess
{
    public class INSNIdentityUser : IdentityUser
    {
        public string Nombres { get; set; } = default!;
        public string ApellidoPaterno { get; set; } = default!;
        public string? ApellidoMaterno { get; set; }
        public string servicio { get; set; } = default!;
        public string? Telefono2 { get; set; }
        public TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; } = default!;
        public int TipoDocumentoIdentidadId { get; set; }
    }
}