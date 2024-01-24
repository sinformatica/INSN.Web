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
using Microsoft.Extensions.Configuration;
using INSN.Web.Repositories.Implementaciones;
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
using INSN.Web.Repositories.Implementaciones.Home.DocumentoInstitucional;
using INSN.Web.Repositories.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.Services.Interfaces.Home.DocumentoInstitucional;
using INSN.Web.Services.Implementaciones.Home.DocumentoInstitucional;
using INSN.Web.Repositories.Interfaces.Home.OportunidadLaboral;
using INSN.Web.Services.Implementaciones.Home.OportunidadLaboral;
using INSN.Web.Repositories.Implementaciones.Home.OportunidadLaboral;
using INSN.Web.Services.Interfaces.Home.OportunidadLaboral;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Vamos a leer el archivo de configuracion con una clase mapeada
builder.Services.Configure<AppConfiguration>(builder.Configuration);

// Add services to the container.

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


// Inyectamos las dependencias
builder.Services.AddTransient<IAccesoService, AccesoService>();
// AutoMapper

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<INSNWebProfile>();
});

builder.Services.AddTransient<ITipoDocumentoService, TipoDocumentoService>();
builder.Services.AddTransient<ITipoDocumentoRepository, TipoDocumentoRepository>();
builder.Services.AddTransient<IDocumentoLegalService, DocumentoLegalService>();
builder.Services.AddTransient<IDocumentoLegalRepository, DocumentoLegalRepository>();
builder.Services.AddTransient<IDocumentoConvocatoriaService, DocumentoConvocatoriaService>();
builder.Services.AddTransient<IDocumentoConvocatoriaRepository, DocumentoConvocatoriaRepository>();
builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<IMenuService, MenuService>();

// Rol
builder.Services.AddTransient<IRolRepository, RolRepository>();
builder.Services.AddTransient<IRolService, RolService>();

// Tipo Documento Identidad
builder.Services.AddTransient<ITipoDocumentoIdentidadRepository, TipoDocumentoIdentidadRepository>();
builder.Services.AddTransient<ITipoDocumentoIdentidadService, TipoDocumentoIdentidadService>();

// Usuario
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();

// Usuario Rol
builder.Services.AddTransient<IUsuarioRolRepository, UsuarioRolRepository>();
builder.Services.AddTransient<IUsuarioRolService, UsuarioRolService>();

// Sistema
builder.Services.AddTransient<ISistemaRepository, SistemaRepository>();
builder.Services.AddTransient<ISistemaService, SistemaService>();

//builder.Services.AddTransient<IFileUploader, AzureBlobStorageUploader>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Registrar el filtro personalizado
builder.Services.AddScoped<CodigoSistemaIdAutorizacion>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Validacion de usuarios y passwords
app.UseAuthentication();
// Validacion de permisos
app.UseAuthorization();

//app.MapGet("api/TipoDocumento", async (ITipoDocumentoService service) =>
//{
//    return Results.Ok(await service.ListAsync());
//});


app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    await UserDataSeeder.Seed(scope.ServiceProvider);
}

app.Run();
