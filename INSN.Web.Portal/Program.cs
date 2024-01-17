using INSN.Web.Portal.Services;
using INSN.Web.Portal.Services.Implementaciones.Acceso;
using INSN.Web.Portal.Services.Implementaciones.Home.DirectorioInstitucional;
using INSN.Web.Portal.Services.Implementaciones.SegApp;
using INSN.Web.Portal.Services.Implementaciones.SegApp.Mantenimiento;
using INSN.Web.Portal.Services.Interfaces.Acceso;
using INSN.Web.Portal.Services.Interfaces.Home.DirectorioInstitucional;
using INSN.Web.Portal.Services.Interfaces.SegApp;
using INSN.Web.Portal.Services.Interfaces.SegApp.Mantenimiento;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Patron singleton para el objeto HttpClient
builder.Services.AddSingleton(_ => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetValue<string>("Backend:ApiRestUrl")!)
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


//INICIO Agregar Los Proxy - Api - DynamiClient
builder.Services.AddScoped<IDocumentoLegalProxy, DocumentoLegalProxy>();
builder.Services.AddScoped<ITipoDocumentoProxy, TipoDocumentoProxy>();
builder.Services.AddScoped<IAccesoProxy, AccesoProxy>();
builder.Services.AddScoped<ISistemaProxy, SistemaProxy>();
builder.Services.AddScoped<IRedireccionarProxy, RedireccionarProxy>();
builder.Services.AddScoped<IMenuProxy, MenuProxy>();
builder.Services.AddScoped<IRolProxy, RolProxy>();
builder.Services.AddScoped<IUsuarioProxy, UsuarioProxy>();
builder.Services.AddScoped<ITipoDocumentoIdentidadProxy, TipoDocumentoIdentidadProxy>();
builder.Services.AddScoped<IUsuarioRolProxy, UsuarioRolProxy>();

//FIN Agregar Los Proxy - Api - DynamiClient
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