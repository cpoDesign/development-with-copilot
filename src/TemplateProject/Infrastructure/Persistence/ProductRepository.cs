using Microsoft.EntityFrameworkCore;
using TemplateProject.Persistence;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TemplateProject.Infrastructure.Persistence;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(AppDbContext context, ILogger<ProductRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        _logger.LogInformation("Querying product {Id}", id);
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
}
