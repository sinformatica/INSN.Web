using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using INSN.Web.Common;
using INSN.Web.DataAccess;
using INSN.Web.Repositories.Implementaciones.Home;
using INSN.Web.Repositories.Interfaces.Home;
using INSN.Web.Services.Implementaciones.Home;
using INSN.Web.Services.Interfaces.Home;
using INSN.Web.Services.Profiles;
using Serilog;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using INSN.Web.Services.Implementaciones;
using INSN.Web.Services.Interfaces;

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
    policies.Lockout.MaxFailedAccessAttempts = 5;
}).AddEntityFrameworkStores<SegAppDbContext>()
.AddDefaultTokenProviders();


// Inyectamos las dependencias
builder.Services.AddTransient<IUserService, UserService>();
// AutoMapper

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<INSNWebProfile>();
});


builder.Services.AddTransient<ITipoDocumentoService, TipoDocumentoService>();
builder.Services.AddTransient<IDocumentoLegalService, DocumentoLegalService>();

//builder.Services.AddTransient<IUserService, UserService>();
//builder.Services.AddTransient<IAlumnoService, AlumnoService>();
//builder.Services.AddTransient<ITallerService, TallerService>();
//builder.Services.AddTransient<IInstructorService, InstructorService>();

builder.Services.AddTransient<IDocumentoLegalRepository, DocumentoLegalRepository>();
builder.Services.AddTransient<ITipoDocumentoRepository, TipoDocumentoRepository>();
//builder.Services.AddTransient<ITallerRepository, TallerRepository>();
//builder.Services.AddTransient<IInstructorRepository, InstructorRepository>();

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
