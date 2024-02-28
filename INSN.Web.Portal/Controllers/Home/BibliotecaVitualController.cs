using DocumentFormat.OpenXml.EMMA;
using INSN.Utilitarios;
using INSN.Web.Common;
using INSN.Web.Models.Request.Home.UsuarioBibliotecas;
using INSN.Web.Models.Response.Home.UsuarioBibliotecas;
using INSN.Web.Portal.Services.Interfaces.Home.UsuarioBibliotecas;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Biblioteca Virtual
/// </summary>
public class BibliotecaVirtualController : Controller
{
    private readonly IUsuarioBibliotecaProxy _proxy;
    private readonly IHttpContextAccessor? _httpContextAccessor;
    private readonly string? Usuario; 

    /// <summary>
    /// Biblioteca Virtual Controller
    /// </summary>
    public BibliotecaVirtualController(IUsuarioBibliotecaProxy proxy, IHttpContextAccessor httpContextAccessor)
    {
        _proxy = proxy;
        _httpContextAccessor = httpContextAccessor;
        Usuario = _httpContextAccessor?.HttpContext?.Session.GetString(Constantes.Usuario);
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        try
        {
            await _proxy.UsuarioBibliotecaInsertar(new UsuarioBibliotecaDtoRequest
            {
                UserName = Usuario,
                FechaLogin = DateTime.Now,
                Estado = Enumerado.Estado.Activo,
                #region [Base Insert]
                EstadoRegistro = 1,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = Usuario,
                TerminalCreacion = Environment.MachineName
                #endregion
            });

            return View("~/Views/Home/BibliotecaVirtual/Index.cshtml");
        }
        catch
        {
            return RedirectToAction("AccesoDenegado", "Acceso");
        }
    }

    /// <summary>
    /// Usuario Biblioteca Exportar Excel
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> UsuarioBibliotecaExportarExcel()
    {
        try
        {
            var data = await _proxy.UsuarioBibliotecaListar(new UsuarioBibliotecaDtoRequest()
            {
                Estado = Enumerado.Estado.Activo,
                EstadoRegistro = Enumerado.EstadoRegistro.Activo
            });

            // Definir los nombres de las columnas que deseas exportar
            List<string> columnNames = new()
            {
            "UserName",
            "FechaLogin",
            "Estado"
            };

            var excelBytes = GestorExcel.ExportarExcel(data, columnNames);

            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UsuarioBiblioteca.xlsx");
        }
        catch (Exception)
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}