using WebApp.Components;
using WebApp.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// HTTP API client for BackendApiService
builder.Services.AddHttpClient<BackendApiService>(options =>
    options.BaseAddress = new Uri(builder.Configuration["BackendApiService:BaseAddress"]));

// Register MudBlazor services for UI components
builder.Services.AddMudServices();

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