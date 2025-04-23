using BackeryApi.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var hostBuilder = Host.CreateDefaultBuilder(args);

var host = hostBuilder
    .ConfigureServices((builder, services) =>
    {
        services.AddBackerySqlServer(builder.Configuration);
    })
    .Build();
    
    var scope = host.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<BackeryDbContext>();
    await dbContext.Database.MigrateAsync();