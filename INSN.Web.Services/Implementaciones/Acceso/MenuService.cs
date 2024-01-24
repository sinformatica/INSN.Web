using AutoMapper;
using INSN.Web.Entities.DocumentoLegal;
using INSN.Web.Models.Response.Home;
using INSN.Web.Models.Response;
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
using INSN.Web.Models.Request.Sistema;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using INSN.Web.DataAccess;
using System.Runtime.CompilerServices;
using INSN.Web.Entities.SegApp;
using INSN.Web.Repositories.Interfaces.Acceso;
using INSN.Web.Services.Interfaces.Acceso;

namespace INSN.Web.Services.Implementaciones.Acceso
{
    /// <summary>
    /// Service Menu
    /// </summary>
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MenuService> _logger;

        /// <summary>
        /// Inicializar
        /// </summary>
        public MenuService(IMenuRepository menuRepository, IMapper mapper, ILogger<MenuService> logger)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
            _logger = logger;
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

                // Suponiendo que _mapper es una instancia de IMapper
                IMapper mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Seccion, SeccionDtoResponse>();
                }).CreateMapper();

                response.Data = lista.Select(x => mapper.Map<SeccionDtoResponse>(x)).ToList();

                if (response.Data.Count > 0)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = "Service: No existen elementos";
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al listar: " + ex.Message;
                _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Modulo Listar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponseGeneric<ICollection<ModuloDtoResponse>>> ModuloListar(ModuloDtoRequest request)
        {
            var response = new BaseResponseGeneric<ICollection<ModuloDtoResponse>>();

            try
            {
                var lista = await _menuRepository.ModuloListar(new Modulo
                {
                    CodigoSeccionId = request.CodigoSeccionId,
                    RolId = request.RolId
                });

                // Suponiendo que _mapper es una instancia de IMapper
                IMapper mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Modulo, ModuloDtoResponse>();
                }).CreateMapper();

                response.Data = lista.Select(x => mapper.Map<ModuloDtoResponse>(x)).ToList();

                if (response.Data.Count > 0)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = "Service: No existen elementos";
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Service: Error al listar: " + ex.Message;
                _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        //public async Task<BaseResponseGeneric<ICollection<ModuloDtoResponse>>> ModuloListar(ModuloDtoRequest request)
        //{
        //    // Llamar al método SeccionListar del repositorio y devolver el resultado
        //    return await _menuRepository.ModuloListar(request);
        //}
    }
}