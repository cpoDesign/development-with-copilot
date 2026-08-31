using TemplateProject.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TemplateProject.Features.Products.DeleteProduct;

public record DeleteProductRequest(Guid Id);

public class DeleteProductHandler
{
    private readonly IProductRepository _repository;
    private readonly ILogger<DeleteProductHandler> _logger;

    public DeleteProductHandler(IProductRepository repository, ILogger<DeleteProductHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> HandleAsync(DeleteProductRequest request)
    {
        var deleted = await _repository.DeleteAsync(request.Id);
        if (deleted)
        {
            _logger.LogInformation("Deleted product {Id}.", request.Id);
        }
        else
        {
            _logger.LogWarning("Delete failed: Product {Id} not found.", request.Id);
        }
        
        return deleted;
    }
}
