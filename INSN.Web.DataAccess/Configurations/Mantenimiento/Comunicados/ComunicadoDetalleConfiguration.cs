﻿using INSN.Web.Entities.Mantenimiento.Comunicado;
using INSN.Web.Entities.SegApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.DataAccess.Configurations.Mantenimiento.Comunicados
{
    public class ComunicadoDetalleConfiguration : IEntityTypeConfiguration<ComunicadoDetalle>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ComunicadoDetalle> builder)
        {
        }
    }
}
