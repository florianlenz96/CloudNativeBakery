using Backery.Application;
using Backery.Application.Products.Handler;
using Backery.Application.Products.Queries;
using BackeryApi.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBackerySqlServer(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/category",
        async (GetCategoriesQueryHandler handler, CancellationToken cancellationToken) =>
            await handler.Handle(new GetCategoriesQuery(), cancellationToken))
    .WithName("GetCategory")
    .WithOpenApi();

app.Run();