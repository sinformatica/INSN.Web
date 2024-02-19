#region[Librerias]
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using INSN.Web.Common;
using INSN.Web.DataAccess;
using INSN.Web.Services.Profiles;
using Serilog;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;
using INSN.Web.Services.Interfaces.SegApp.Mantenimiento;
using INSN.Web.Services.Implementaciones.SegApp.Mantenimiento;
using INSN.Web.Repositories.Interfaces.SegApp.Mantenimiento;
using INSN.Web.Repositories.Implementaciones.SegApp.Mantenimiento;
using INSN.Web.Repositories.Implementaciones.SegApp;
using INSN.Web.Services.Implementaciones.SegApp;
using INSN.Web.Services.Interfaces.SegApp;
using INSN.Web.Repositories.Interfaces.SegApp;
using INSN.Web.DataAccess.Acceso;
using INSN.Web.Repositories.Implementaciones.Acceso;
using INSN.Web.Repositories.Interfaces.Acceso;
using INSN.Web.Services.Interfaces.Acceso;
using INSN.Web.Services.Implementaciones.Acceso;
using INSN.Web.ApiRest.Controllers;
using INSN.Web.Repositories.Implementaciones.Home.LibroReclamaciones;
using INSN.Web.Repositories.Interfaces.Home.LibroReclamaciones;
using INSN.Web.Services.Implementaciones.Home.LibroReclamaciones;
using INSN.Web.Services.Interfaces.Home.LibroReclamaciones;
using INSN.Web.Repositories.Implementaciones.Util;
using INSN.Web.Services.Implementaciones.Util;
using INSN.Web.Services.Interfaces.Util;
using INSN.Web.Repositories.Interfaces.Util;
#endregion

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Vamos a leer el archivo de configuracion con una clase mapeada
builder.Services.Configure<AppConfiguration>(builder.Configuration);

// AutoMapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<INSNWebProfile>();
});

#region[DbContext]
builder.Services.AddDbContext<INSNWebDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("INSNDatabase"));
    options.EnableSensitiveDataLogging();

    options.ConfigureWarnings(p =>
        p.Ignore(CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning));

    options.ConfigureWarnings(p =>
        p.Ignore(CoreEventId.SensitiveDataLoggingEnabledWarning));
});

builder.Services.AddDbContext<SegAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SegAppDatabase"));
});

builder.Services.AddDbContext<SegAppDbContextEF>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SegAppDatabase"));
});
#endregion

#region[Identity]
builder.Services.AddIdentity<INSNIdentityUser, IdentityRole>(policies =>
{
    // politicas de contraseña
    policies.Password.RequireDigit = true;
    policies.Password.RequireLowercase = true;
    policies.Password.RequireUppercase = false;
    policies.Password.RequireNonAlphanumeric = false;
    policies.Password.RequiredLength = 6;

    // todos los usuarios deben ser unicos
    policies.User.RequireUniqueEmail = true;

    // politica de bloqueo de cuenta
    policies.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    policies.Lockout.MaxFailedAccessAttempts = 10;
}).AddEntityFrameworkStores<SegAppDbContext>()
.AddDefaultTokenProviders();
#endregion

#region[Inyectar dependecias]
#region[Acceso]
builder.Services.AddTransient<IAccesoService, AccesoService>();

// Sistema
builder.Services.AddTransient<ISistemaRepository, SistemaRepository>();
builder.Services.AddTransient<ISistemaService, SistemaService>();
#endregion

#region[Menú]
builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<IMenuService, MenuService>();
#endregion

#region[SegApp]
// Rol
builder.Services.AddTransient<IRolRepository, RolRepository>();
builder.Services.AddTransient<IRolService, RolService>();

// Usuario
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();

// Usuario Rol
builder.Services.AddTransient<IUsuarioRolRepository, UsuarioRolRepository>();
builder.Services.AddTransient<IUsuarioRolService, UsuarioRolService>();
#endregion

#region[Tipo Documento Identidad]
builder.Services.AddTransient<ITipoDocumentoIdentidadRepository, TipoDocumentoIdentidadRepository>();
builder.Services.AddTransient<ITipoDocumentoIdentidadService, TipoDocumentoIdentidadService>();
#endregion

#region[Libro Reclamacion]
builder.Services.AddTransient<ILibroReclamacionRepository, LibroReclamacionRepository>();
builder.Services.AddTransient<ILibroReclamacionService, LibroReclamacionService>();
#endregion

#region[Correo Credencial]
builder.Services.AddTransient<ICorreoCredencialRepository, CorreoCredencialRepository>();
builder.Services.AddTransient<ICorreoCredencialService, CorreoCredencialService>();
#endregion
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region[Configuracion JWToken]
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    var key = Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:SecretKey") ??
        throw new InvalidOperationException("No se configuró el JWT"));

    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Emisor"],
        ValidAudience = builder.Configuration["Jwt:Audiencia"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});
#endregion

#region[Filtros personalizados]
// Filtro para validar el CodigoSistemaId
builder.Services.AddScoped<CodigoSistemaIdAutorizacion>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

// Validacion de usuarios y passwords
app.UseAuthentication();
// Validacion de permisos
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    await UserDataSeeder.Seed(scope.ServiceProvider);
}

app.Run();