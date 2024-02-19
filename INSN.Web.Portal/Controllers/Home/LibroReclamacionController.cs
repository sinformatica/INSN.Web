using INSN.Web.Portal.Services.Interfaces.SegApp;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.ViewModels.Home.LibroReclamacion;
using INSN.Web.ViewModels.Exceptions;
using INSN.Web.Models.Request.Home.LibroReclamaciones;
using INSN.Web.Portal.Services.Interfaces.Home.LibroReclamaciones;
using INSN.Web.Common;
using static INSN.Web.Common.Enumerado;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Libro Reclamacion
/// </summary>
public class LibroReclamacionController : Controller
{
    private readonly ILibroReclamacionProxy _proxy;
    private readonly ITipoDocumentoIdentidadProxy _proxyTipoDocumentoIdentidad;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Libro Reclamacion Controller
    /// </summary>
    /// <param name="LibroReclamacion"></param>
    /// <param name="TipoDocumentoIdentidad"></param>
    public LibroReclamacionController(ILibroReclamacionProxy LibroReclamacion, ITipoDocumentoIdentidadProxy TipoDocumentoIdentidad,
                                IConfiguration configuration)
    {
        _proxy = LibroReclamacion;
        _proxyTipoDocumentoIdentidad = TipoDocumentoIdentidad;
        _configuration = configuration;
    }

    /// <summary>
    /// Cargar Página Index
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<IActionResult> Index(LibroReclamacionViewModel model)
    {
        var resultTiposDocumentos = await _proxyTipoDocumentoIdentidad.TipoDocumentoIdentidadListar(new TipoDocumentoIdentidadDtoRequest()
        {
            Estado = Estado.Activo,
            EstadoRegistro = EstadoRegistro.Activo
        });

        model.TiposDocumentosIdentidad = resultTiposDocumentos;

        return View("~/Views/Home/LibroReclamacion/Index.cshtml", model);
    }

    /// <summary>
    /// Libro Reclamacion Insertar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> LibroReclamacionInsertar(LibroReclamacionViewModel request)
    {
        try
        {
            var resultTiposDocumentos = await _proxyTipoDocumentoIdentidad.TipoDocumentoIdentidadListar(new TipoDocumentoIdentidadDtoRequest()
            {
                Estado = Estado.Activo,
                EstadoRegistro = EstadoRegistro.Activo
            });

            request.TiposDocumentosIdentidad = resultTiposDocumentos;

            if (request.TipoPersonaSeleccionada == "Natural")
            {
                if (string.IsNullOrWhiteSpace(request.DocumentoIdentidad))
                    throw new ModelException(nameof(request.DocumentoIdentidad), "Campo requerido: Documento de Identidad");

                if (string.IsNullOrWhiteSpace(request.Nombres))
                    throw new ModelException(nameof(request.Nombres), "Campo requerido: Nombres");

                if (string.IsNullOrWhiteSpace(request.ApellidoPaterno))
                    throw new ModelException(nameof(request.ApellidoPaterno), "Campo requerido: Apellido Paterno");

                if (string.IsNullOrWhiteSpace(request.ApellidoMaterno))
                    throw new ModelException(nameof(request.ApellidoMaterno), "Campo requerido: Apellido Materno");
            }

            else if (request.TipoPersonaSeleccionada == "Juridica")
            {
                if (string.IsNullOrWhiteSpace(request.RUC))
                    throw new ModelException(nameof(request.RUC), "Campo requerido: RUC");

                if (string.IsNullOrWhiteSpace(request.RazonSocial))
                    throw new ModelException(nameof(request.RUC), "Campo requerido: Razón Social");
            }

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ModelException(nameof(request.Email), "Campo requerido: Email");

            if (string.IsNullOrWhiteSpace(request.Reclamo))
                throw new ModelException(nameof(request.Reclamo), "Campo requerido: Reclamo");

            if (request.Autorizacion == false)
                throw new ModelException(nameof(request.Autorizacion), "Campo requerido: Autorización");

            //await _proxy.LibroReclamacionInsertar(new LibroReclamacionDtoRequest
            //{
            //    TipoPersona = request.TipoPersonaSeleccionada,
            //    TipoDocumentoIdentidad = request.TipoDocumentoIdentidadSeleccionada,
            //    DocumentoIdentidad = request.DocumentoIdentidad,
            //    RUC = request.RUC,
            //    RazonSocial = request.RazonSocial,
            //    Nombres = request.Nombres,
            //    ApellidoPaterno = request.ApellidoPaterno,
            //    ApellidoMaterno = request.ApellidoMaterno,
            //    Direccion = request.Direccion,
            //    CelularTelefono = request.CelularTelefono,
            //    Email = request.Email,
            //    Reclamo = request.Reclamo,
            //    TipoParentesco = request.TipoParentescoSeleccionada,
            //    TipoDocumentoIdentidadPaciente = request.TipoDocumentoIdentidadPacienteSeleccionada,
            //    DocumentoIdentidadPaciente = request.DocumentoIdentidadPaciente,
            //    NombrePaciente = request.NombrePaciente,
            //    ApellidoPaternoPaciente = request.ApellidoPaternoPaciente,
            //    ApellidoMaternoPaciente = request.ApellidoMaternoPaciente,
            //    Autorizacion = request.Autorizacion,
            //    Estado = Estado.Activo,
            //    #region [Base Insert]
            //    EstadoRegistro = EstadoRegistro.Activo,
            //    FechaCreacion = DateTime.Now,
            //    UsuarioCreacion = Environment.UserName,
            //    TerminalCreacion = Environment.MachineName
            //    #endregion
            //});

            EnviarCorreo();

            #region[Controles de Codigo/Controller]
            TempData["CodigoMensaje"] = 1;
            TempData["Mensaje"] = "Registro enviado correctamente";
            TempData["Metodo"] = "Index";
            TempData["Controlador"] = "LibroReclamacion";
            #endregion           

            return View("~/Views/Home/LibroReclamacion/Index.cshtml", request);
        }
        catch (ModelException ex)
        {
            ModelState.AddModelError(ex.PropertyName, ex.Message);
            return View("~/Views/Home/LibroReclamacion/Index.cshtml", request);
        }
        catch (Exception ex)
        {
            TempData["CodigoMensaje"] = -1;
            TempData["Mensaje"] = ex.Message;

            return View("~/Views/Home/LibroReclamacion/Index.cshtml", request);
        }
    }

    /// <summary>
    /// Enviar correo
    /// </summary>
    public void EnviarCorreo()
    {
        string toAddress = "jriveros@sise.com.pe";
        string asunto = "Asunto del correo";
        string cuerpoMensaje = "Este es el cuerpo del mensaje del correo.";

        var emailSettings = _configuration.GetSection("EmailSettings");
        var fromAddress = emailSettings["FromAddress"];
        var smtpServer = emailSettings["SmtpServer"];
        var port = int.Parse(emailSettings["Port"]);
        var userName = emailSettings["UserName"];
        var password = emailSettings["Password"];

        using (MailMessage message = new MailMessage(fromAddress, toAddress))
        {
            message.Subject = asunto;
            message.Body = cuerpoMensaje;
            message.IsBodyHtml = true;

            using (SmtpClient smtp = new SmtpClient(smtpServer, port))
            {
                smtp.Credentials = new NetworkCredential(userName, password);
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}