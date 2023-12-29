using AutoMapper;
using INSN.Web.Entities.DocumentoLegal;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response;
using INSN.Web.Repositories.Interfaces;
using INSN.Web.Repositories.Interfaces.Home;
using INSN.Web.Services.Implementaciones.Home;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using INSN.Web.Models.Response.Sistema;
using INSN.Web.Entities;
using INSN.Web.Models.Request.Sistema;
using INSN.Web.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using INSN.Web.DataAccess;
using System.Runtime.CompilerServices;

namespace INSN.Web.Services.Implementaciones
{
    /// <summary>
    /// Service Menu
    /// </summary>
    public class MenuService: IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializar
        /// </summary>
        public MenuService(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<SeccionDtoResponse>>> SeccionListar(SeccionDtoRequest request)
        {
            var response = new BaseResponseGeneric<ICollection<SeccionDtoResponse>>();

            try
            {
                var lista = await _menuRepository.SeccionListar(new Seccion
                {
                    CodigoSistemaId = request.CodigoSistemaId,
                    RolId = request.RolId                  
                });

                response.Data = lista.Select(x => _mapper.Map<SeccionDtoResponse>(x)).ToList();

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al listar: " + ex.Message;
               // _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        ///// <summary>
        ///// Modulo Listar
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<BaseResponseGeneric<ICollection<ModuloDtoResponse>>> ModuloListar(ModuloDtoRequest request)
        //{
        //    // Llamar al método SeccionListar del repositorio y devolver el resultado
        //    return await _menuRepository.ModuloListar(request);
        //}
    }
}