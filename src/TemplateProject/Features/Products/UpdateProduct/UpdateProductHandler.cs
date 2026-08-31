using TemplateProject.Domain;
using TemplateProject.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TemplateProject.Features.Products.UpdateProduct;

public record UpdateProductRequest(Guid Id, string Name, string Description, decimal Price);

public class UpdateProductHandler
{
    private readonly IProductRepository _repository;
    private readonly ILogger<UpdateProductHandler> _logger;

    public UpdateProductHandler(IProductRepository repository, ILogger<UpdateProductHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> HandleAsync(UpdateProductRequest request)
    {
        var product = await _repository.GetByIdAsync(request.Id);
        if (product == null)
        {
            _logger.LogWarning("Update failed: Product {Id} not found.", request.Id);
            return false;
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;

        await _repository.UpdateAsync(product);
        _logger.LogInformation("Updated product {Id}.", request.Id);
        
        return true;
    }
}
