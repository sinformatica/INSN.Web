using INSN.Web.Portal.Services.Implementaciones;
using INSN.Web.Portal.Services.Interfaces;

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


//FIN Agregar Los Proxy - Api - DynamiClient
builder.Services.AddDistributedMemoryCache();


#region [Sistema]
/*INICIO Sistema*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
/*FIN Sistema*/
#endregion