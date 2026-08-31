using TemplateProject.Domain;
using TemplateProject.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TemplateProject.Features.Products.GetProduct;

public record GetProductRequest(Guid Id);

public class GetProductHandler
{
    private readonly IProductRepository _repository;
    private readonly ICacheService _cache;
    private readonly ILogger<GetProductHandler> _logger;

    public GetProductHandler(IProductRepository repository, ICacheService cache, ILogger<GetProductHandler> logger)
    {
        _repository = repository;
        _cache = cache;
        _logger = logger;
    }

    public async Task<ProductDto> HandleAsync(GetProductRequest request)
    {
        var cacheKey = $"product_{request.Id}";
        
        var cached = _cache.Get<ProductDto>(cacheKey);
        if (cached != null)
        {
            _logger.LogInformation("Cache hit for {Id}", request.Id);
            return cached;
        }

        var product = await _repository.GetByIdAsync(request.Id);
        if (product == null) return null;

        var dto = new ProductDto(product.Id, product.Name, product.Price);
        
        _cache.Set(cacheKey, dto);
        
        _logger.LogInformation("Cache miss for {Id}. Loaded from DB.", request.Id);
        return dto;
    }
}

using TemplateProject.Domain;

public class GetProductHandler
{
    private readonly IProductRepository _repository;
    private readonly ICacheService _cache;
    private readonly ILogger<GetProductHandler> _logger;

    public GetProductHandler(IProductRepository repository, ICacheService cache, ILogger<GetProductHandler> logger)
    {
        _repository = repository;
        _cache = cache;
        _logger = logger;
    }

    public async Task<ProductDto> HandleAsync(GetProductRequest request)
    {
        var cacheKey = $"product_{request.Id}";
        
        var cached = _cache.Get<ProductDto>(cacheKey);
        if (cached != null)
        {
            _logger.LogInformation("Cache hit for {Id}", request.Id);
            return cached;
        }

        var product = await _repository.GetByIdAsync(request.Id);
        if (product == null) return null;

        var dto = new ProductDto(product.Id, product.Name, product.Price);
        
        _cache.Set(cacheKey, dto);
        
        _logger.LogInformation("Cache miss for {Id}. Loaded from DB.", request.Id);
        return dto;
    }
}

