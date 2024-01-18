﻿using INSN.Web.Entities.DocumentoInstitucional;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INSN.Web.DataAccess.Configurations.DocumentoInstitucional
{
    /// <summary>
    /// Configuracion de Tabla Tipo Documento
    /// </summary>
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        /// <summary>
        /// Seteo de Parametros
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<TipoDocumento> builder)
        {           
        }
    }
}