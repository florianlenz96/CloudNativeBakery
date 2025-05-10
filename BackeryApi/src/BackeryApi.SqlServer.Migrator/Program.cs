using BackeryApi.Domain.Products;
using BackeryApi.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddBackerySqlServer(builder.Configuration);

builder.Build();

var scope = builder.Services.BuildServiceProvider().CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<BackeryDbContext>();
await dbContext.Database.MigrateAsync();

dbContext.Categories.Add(new Category
{
    Name = "Backwaren",
    Articles = new []
    {
        new Article
        {
            Name = "Brot",
            Price = 1.99,
        },
        new Article
        {
            Name = "Brötchen",
            Price = 0.49,
        },
        new Article
        {
            Name = "Croissant",
            Price = 1.29,
        },
    }
});
dbContext.Categories.Add(new Category
{
    Name = "Getränke",
    Articles = new []
    {
        new Article
        {
            Name = "Wasser",
            Price = 0.99,
        },
        new Article
        {
            Name = "Cola",
            Price = 1.49,
        },
        new Article
        {
            Name = "Saft",
            Price = 1.19,
        },
    }
});

await dbContext.SaveChangesAsync();