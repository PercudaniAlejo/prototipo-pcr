using ApexCharts;
using Flowbite.Services;
using PCR.Core.Application.Features.Auth.Commands;
using PCR.Core.Application.Interfaces.Services;
using PCR.Infrastructure.Shared.Services;
using PCR.Web.Server.Components;

var builder = WebApplication.CreateBuilder(args);

// Configurar localizacion - Los archivos .resx estan en la raiz del proyecto
builder.Services.AddLocalization();

// Add MockDataService para consumir archivos JSON (Prototipo)
builder.Services.AddScoped<IMockDataService, MockDataService>();

// Add MediatR - Escanear el assembly de Application
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(LoginCommand).Assembly);
});

// Add Flowbite services
builder.Services.AddFlowbite();

// Add services to the container with Auto render mode support
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddApexCharts();

var app = builder.Build();

// Configurar las culturas soportadas
var supportedCultures = new[] { "es-ES", "en-US" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("es-ES")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

// Configure Razor Components with Auto render mode
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();

app.Run();
