using Microsoft.AspNetCore.Mvc;
using TemplateProject.Persistence;
using TemplateProject.Infrastructure.Persistence;
using TemplateProject.Features.Products.GetProduct;
using TemplateProject.Features.Products.CreateProduct;
using TemplateProject.Features.Products.UpdateProduct;
using TemplateProject.Features.Products.DeleteProduct;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Persistence - In Memory for now as per requirement
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseInMemoryDatabase("TrainingDb"));

builder.Services.AddSingleton<ICacheService, InMemoryCacheService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Register Handlers
builder.Services.AddScoped<GetProductHandler>();
builder.Services.AddScoped<CreateProductHandler>();
builder.Services.AddScoped<UpdateProductHandler>();
builder.Services.AddScoped<DeleteProductHandler>();

builder.Services.AddLogging(logging => {
    logging.AddConsole();
});

var app = builder.Build();

// Endpoints
app.MapGet("/products/{id}", async (Guid id, GetProductHandler handler) => {
    var result = await handler.HandleAsync(new GetProductRequest(id));
    return result is null ? Results.NotFound() : Results.Ok(result);
});

app.MapPost("/products", async (CreateProductRequest request, CreateProductHandler handler) => {
    var id = await handler.HandleAsync(request);
    return Results.Created($"/products/{id}", new { Id = id });
});

app.MapPut("/products/{id}", async (Guid id, UpdateProductRequest request, UpdateProductHandler handler) => {
    var success = await handler.HandleAsync(new UpdateProductRequest(id, request.Name, request.Description, request.Price));
    return success ? Results.NoContent() : Results.BadRequest();
});

app.MapDelete("/products/{id}", async (Guid id, DeleteProductRequest request, DeleteProductHandler handler) => {
    var success = await handler.HandleAsync(new DeleteProductRequest(id));
    return success ? Results.NoContent() : Results.NotFound();
});

app.Run();
