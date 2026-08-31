using TemplateProject.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TemplateProject.Infrastructure.Persistence;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddAsync(Product product);
}
