using INSN.Web.Portal.Services.Interfaces.SegApp;
using Microsoft.AspNetCore.Mvc;
using INSN.Web.Models.Request.SegApp;
using INSN.Web.ViewModels.Home.LibroReclamacion;
using INSN.Web.ViewModels.Exceptions;
using INSN.Web.Models.Request.Home.LibroReclamaciones;
using INSN.Web.Portal.Services.Interfaces.Home.LibroReclamaciones;
using static INSN.Web.Common.Enumerado;
using System.Net.Mail;
using System.Net;
using INSN.Web.Portal.Services.Interfaces.Util;
using INSN.Utilitarios;

namespace INSN.Web.Portal.Controllers.Home;

/// <summary>
/// Controlador Libro Reclamacion
/// </summary>
public class LibroReclamacionController : Controller
{
    private readonly ILibroReclamacionProxy _proxy;
    private readonly ICorreoCredencialProxy _proxyCorreoCrendencial;
    private readonly ITipoDocumentoIdentidadProxy _proxyTipoDocumentoIdentidad;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Libro Reclamacion Controller
    /// </summary>
    /// <param name="LibroReclamacion"></param>
    /// <param name="TipoDocumentoIdentidad"></param>
    /// <param name="configuration"></param>
    /// <param name="proxyCorreoCrendencial"></param>
    public LibroReclamacionController(ILibroReclamacionProxy LibroReclamacion, ITipoDocumentoIdentidadProxy TipoDocumentoIdentidad,
                                IConfiguration configuration, ICorreoCredencialProxy proxyCorreoCrendencial)
    {
        _proxy = LibroReclamacion;
        _proxyTipoDocumentoIdentidad = TipoDocumentoIdentidad;
        _configuration = configuration;
        _proxyCorreoCrendencial = proxyCorreoCrendencial;
    }

    /// <summary>
    /// Cargar Página Inicio
    /// </summary>
    /// <returns></returns>
    public IActionResult Inicio()
    {
        return View("~/Views/Home/LibroReclamacion/Inicio.cshtml");
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

            #region[Validar campos]
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

            if (request.Imagen != null)
            {
                if (request.Imagen.Length > 0)
                {
                    CarpetaHelper.ValidarArchivo(new List<string> { "imagen" }, 5, request.Imagen);
                }
            }

            if (request.Autorizacion == false)
                throw new ModelException(nameof(request.Autorizacion), "Campo requerido: Autorización");
            #endregion

            request.CodigoLibroReclamacionId = await _proxy.LibroReclamacionInsertar(new LibroReclamacionDtoRequest
            {
                TipoPersona = request.TipoPersonaSeleccionada,
                TipoDocumentoIdentidad = request.TipoDocumentoIdentidadSeleccionada,
                DocumentoIdentidad = request.DocumentoIdentidad,
                RUC = request.RUC,
                RazonSocial = request.RazonSocial,
                Nombres = request.Nombres,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                Direccion = request.Direccion,
                CelularTelefono = request.CelularTelefono,
                Email = request.Email,
                Reclamo = request.Reclamo,
                RutaImagen = "",
                TipoParentesco = request.TipoParentescoSeleccionada,
                TipoDocumentoIdentidadPaciente = request.TipoDocumentoIdentidadPacienteSeleccionada,
                DocumentoIdentidadPaciente = request.DocumentoIdentidadPaciente,
                NombrePaciente = request.NombrePaciente,
                ApellidoPaternoPaciente = request.ApellidoPaternoPaciente,
                ApellidoMaternoPaciente = request.ApellidoMaternoPaciente,
                Autorizacion = request.Autorizacion,
                Estado = Estado.Activo,
                #region [Base Insert]
                EstadoRegistro = EstadoRegistro.Activo,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = Environment.UserName,
                TerminalCreacion = Environment.MachineName
                #endregion
            });

            #region [Imagen]
            if (request.Imagen != null && request.Imagen.Length > 0)
            {
                try
                {
                    string Nombre = "Reclamo_" + request.CodigoLibroReclamacionId;

                    //Guardar imagen en el file server
                    request.RutaImagen = await (request.Imagen != null ? CarpetaHelper.GuardarArchivo("Reclamos", "", Nombre, request.Imagen) : Task.FromResult(string.Empty));
                }
                catch (Exception ex)
                {
                    TempData["CodigoMensaje"] = -1;
                    TempData["Mensaje"] = ex.Message;

                    return View("~/Views/Home/LibroReclamacion/Index.cshtml", request);
                }

                // Actualizar campo Ruta imagen en la bd
                await _proxy.LibroReclamacionRutaImagenActualizar(request.CodigoLibroReclamacionId, request.RutaImagen);
            }
            #endregion

            // Enviar correo
            await EnviarCorreo(request);

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
    public async Task EnviarCorreo(LibroReclamacionViewModel request)
    {
        // Destinatario
        string? NombreDestinatario = "";

        if (request.TipoPersonaSeleccionada == "Natural")
            NombreDestinatario = $"{request.ApellidoPaterno} {request.ApellidoMaterno} {request.Nombres}";
        else
            NombreDestinatario = request.RazonSocial;
        
        string? toAddress = request.Email ?? "";
        string asunto = $"INSN RECLAMO #{request.CodigoLibroReclamacionId}";

        // Remitente
        var credenciales = await _proxyCorreoCrendencial.ObtenerCorreoCredencial();
        string? fromAddress = credenciales.Usuario ?? "";
        string? smtpServer = credenciales.Host ?? "";
        int port = credenciales.Puerto != 0 ? credenciales.Puerto : 0;
        string? userName = credenciales.Usuario ?? "";
        string? password = credenciales.Clave ?? "";

        #region[Cuerpo del mensaje]
        #region[Logo]
        var FileServer = _configuration.GetSection("FileServer");
        string? ruta = FileServer["RutaImagenLogo"];
        byte[]? ImagenBytes = ruta != null ? System.IO.File.ReadAllBytes(ruta) : null;
        var base64 = Convert.ToBase64String(ImagenBytes ?? Array.Empty<byte>());
        var imagenDataUrl = string.Format("data:image/png;base64,{0}", base64);
        #endregion

        string? cuerpoMensaje = $"<h3>Estimado(a), {NombreDestinatario}</h3>";
        cuerpoMensaje += "Te informamos que hemos recibido tu reclamo:<br><br>";
        cuerpoMensaje += "<p style='text-align: justify;'>" + request.Reclamo + "</p>";
        cuerpoMensaje += "<br>";
        cuerpoMensaje += "<p>Se revisará y se te notificará la resolución del mismo.</p>";
        cuerpoMensaje += "<p>Agradecemos tu compresión de antemano.</p>";
        cuerpoMensaje += "<br><br>";
        cuerpoMensaje += "Atte.<br>";
        cuerpoMensaje += "Instituto Nacional de Salud del Niño - Breña <br>";
        cuerpoMensaje += "<img src='" + imagenDataUrl + "' style='height: 100px;' />";
        #endregion

        using (MailMessage message = new MailMessage(fromAddress, toAddress))
        {
            message.Subject = asunto;
            message.Body = cuerpoMensaje;
            message.IsBodyHtml = true;

            // Adjuntar la imagen al correo electrónico
            if (!string.IsNullOrEmpty(request.RutaImagen))
            {
                Attachment attachment = new Attachment(request.RutaImagen);
                message.Attachments.Add(attachment);
            }

            using (SmtpClient smtp = new SmtpClient(smtpServer, port))
            {
                smtp.Credentials = new NetworkCredential(userName, password);
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}