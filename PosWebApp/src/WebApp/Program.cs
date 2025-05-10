using MudBlazor;
using WebApp.Components;
using WebApp.Services;
using MudBlazor.Services;
using Dapr.Client;

var builder = WebApplication.CreateBuilder(args);

// HTTP API client for BackendApiService
builder.Services.AddDaprClient();
builder.Services.AddTransient<BackendApiService>();

// Register MudBlazor services for UI components
builder.Services.AddMudServices();

// Register BasketService to manage the shopping basket
builder.Services.AddSingleton<BasketService>();

// Add Blazor interactive components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Error handling for non-development environments
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Map the Blazor app
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();