using INSN.Web.Models;
using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSN.Web.Services.Interfaces.SegApp.Mantenimiento
{
    /// <summary>
    /// Interface Servicio Rol
    /// </summary>
    public interface IRolService
    {
        /// <summary>
        /// Rol Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<RolDtoResponse>>> RolListar(RolDtoRequest request);

        /// <summary>
        /// IService: Listar Rol con Paginación
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Estado"></param>
        /// <param name="EstadoRegistro"></param>
        /// <param name="Page"></param>
        /// <param name="Rows"></param>
        /// <returns></returns>
        //Task<PaginationResponse<RolDtoResponse>> Listar(string? Name,
        //    string? Estado, int EstadoRegistro, int Page, int Rows);
    }
}
