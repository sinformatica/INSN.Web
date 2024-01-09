using INSN.Web.Models.Request.SegApp.Mantenimiento;
using INSN.Web.Models.Response.SegApp.Mantenimiento;
using INSN.Web.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.Models;

namespace INSN.Web.Services.Interfaces
{
    public interface ITipoDocumentoIdentidadService
    {
        /// <summary>
        /// Tipo Documento Identidad Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponseGeneric<ICollection<TipoDocumentoIdentidadDtoResponse>>> TipoDocumentoIdentidadListar();
    }
}
