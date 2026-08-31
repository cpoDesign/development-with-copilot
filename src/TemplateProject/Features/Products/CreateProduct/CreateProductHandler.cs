using TemplateProject.Domain;
using TemplateProject.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TemplateProject.Features.Products.CreateProduct;

public record CreateProductRequest(string Name, string Description, decimal Price);

public class CreateProductHandler
{
    private readonly IProductRepository _repository;
    private readonly ILogger<CreateProductHandler> _logger;

    public CreateProductHandler(IProductRepository repository, ILogger<CreateProductHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Guid> HandleAsync(CreateProductRequest request)
    {
        // Basic validation as per security-contracts.md
        if (string.IsNullOrWhiteSpace(request.Name) || request.Name.Length > 255)
        {
            throw new ArgumentException("Invalid Name. Must not be empty and max 255 chars.");
        }
        if (request.Price < 0)
        {
            throw new ArgumentException("Price cannot be negative.");
        }

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        await _repository.AddAsync(product);
        _logger.LogInformation("Created product {Id} with name {Name}", product.Id, product.Name);
        
        return product.Id;
    }
}
