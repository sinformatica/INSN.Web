using INSN.Web.Portal.Services.Implementaciones.Acceso;
using INSN.Web.Portal.Services.Implementaciones.Home.Comunicados;
using INSN.Web.Portal.Services.Implementaciones.Home.DocumentoInstitucional;
using INSN.Web.Portal.Services.Implementaciones.Home.LibroReclamaciones;
using INSN.Web.Portal.Services.Implementaciones.Home.Noticias;
using INSN.Web.Portal.Services.Implementaciones.Home.OportunidadLaboral;
using INSN.Web.Portal.Services.Implementaciones.SegApp;
using INSN.Web.Portal.Services.Implementaciones.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Interfaces.Acceso;
using INSN.Web.Portal.Services.Interfaces.Home.Comunicados;
using INSN.Web.Portal.Services.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.Portal.Services.Interfaces.Home.LibroReclamaciones;
using INSN.Web.Portal.Services.Interfaces.Home.Noticias;
using INSN.Web.Portal.Services.Interfaces.Home.OportunidadLaboral;
using INSN.Web.Portal.Services.Interfaces.SegApp;
using INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Util;
using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
        .WriteTo.Console(LogEventLevel.Information)
        .WriteTo.File("logs.log",
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] - {Message}{NewLine}{Exception}",
            rollingInterval: RollingInterval.Day,
            restrictedToMinimumLevel: LogEventLevel.Warning)
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region[Agregar Url Apis]
builder.Services.AddHttpClientIfConfigured("ApiHttpClient", builder.Configuration, "Backend:ApiRestUrl");
builder.Services.AddHttpClientIfConfigured("ApiWebAdminHttpClient", builder.Configuration, "Backend:ApiRestUrlWebAdmin");
#endregion

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

#region[Inyectar dependecias]
builder.Services.AddProxy<IDocumentoLegalProxy, DocumentoLegalProxy>("ApiHttpClient");
builder.Services.AddProxy<ITipoDocumentoProxy, TipoDocumentoProxy>("ApiHttpClient");
builder.Services.AddProxy<IDocumentoConvocatoriaProxy, ConvocatoriaProxy>("ApiHttpClient");
builder.Services.AddProxy<ISistemaProxy, SistemaProxy>("ApiHttpClient");
builder.Services.AddProxy<IRedireccionarProxy, RedireccionarProxy>("ApiHttpClient");
builder.Services.AddProxy<IMenuProxy, MenuProxy>("ApiHttpClient");
builder.Services.AddProxy<IRolProxy, RolProxy>("ApiHttpClient");
builder.Services.AddProxy<IUsuarioProxy, UsuarioProxy>("ApiHttpClient");
builder.Services.AddProxy<ITipoDocumentoIdentidadProxy, TipoDocumentoIdentidadProxy>("ApiHttpClient");
builder.Services.AddProxy<IUsuarioRolProxy, UsuarioRolProxy>("ApiHttpClient");
builder.Services.AddProxy<IAccesoProxy, AccesoProxy>("ApiHttpClient");
builder.Services.AddProxy<ILibroReclamacionProxy, LibroReclamacionProxy>("ApiHttpClient");
builder.Services.AddProxy<IComunicadoProxy, ComunicadoProxy>("ApiWebAdminHttpClient");
builder.Services.AddProxy<INoticiaProxy, NoticiaProxy>("ApiWebAdminHttpClient");
#endregion

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120); // 2 horas
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "WebINSN";
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
        options.LoginPath = "/Acceso/Login";
        options.AccessDeniedPath = "/Acceso/AccesoDenegado";
        options.SlidingExpiration = true;
    });

#region [Sistema]
/*INICIO Sistema*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
/*FIN Sistema*/
#endregion