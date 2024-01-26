﻿using INSN.Web.DataAccess;
using INSN.Web.Entities.DocumentoInstitucional;
using INSN.Web.Entities.Mantenimiento.Comunicado;
using INSN.Web.Repositories.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.Repositories.Interfaces.Mantenimiento.Comunicados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Repositories.Implementaciones.Mantenimiento.Comunicados
{
    public class ComunicadoRepository : RepositoryBase<Comunicado>, IComunicadoRepository
    {
        /// <summary>
        /// INSNWebDBContext
        /// </summary>
        /// <param name="context"></param>
        public ComunicadoRepository(INSNWebDBContext context) : base(context)
        {
        }

        /// <summary>
        /// Repository: Comunicado Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<Comunicado>> ComunicadoListar(Comunicado request)
        {
            Expression<Func<Comunicado, bool>> predicate =
                    x => x.Titulo.Contains(request.Titulo ?? string.Empty)
                         && (request.FechaExpiracion == null || x.FechaExpiracion >= request.FechaExpiracion)
                         && (request.Estado == null || x.Estado == request.Estado)
                         && x.EstadoRegistro == request.EstadoRegistro;

            return await Context.Set<Comunicado>()
                .Where(predicate)
                .Select(p => new Comunicado
                {
                    CodigoComunicadoId = p.CodigoComunicadoId,
                    Titulo = p.Titulo,
                    FechaPublicacion = p.FechaPublicacion,
                    FechaExpiracion = p.FechaExpiracion,
                    NombreModal = p.NombreModal,
                    NombreImagenPortada = p.NombreImagenPortada,
                    Ancho = p.Ancho,
                    Estado = p.Estado,
                    EstadoRegistro = p.EstadoRegistro
                })
                .ToListAsync();
        }
    }
}