using TemplateProject.Domain;
using Microsoft.Extensions.Logging;

namespace TemplateProject.Infrastructure.Persistence;

public interface IOrderRepository
{
    Task<Order> CreateOrderAsync(Order order);
}

public class OrderRepository : IOrderRepository
{
    private readonly ILogger<OrderRepository> _logger;
    public OrderRepository(ILogger<OrderRepository> logger) => _logger = logger;

    public async Task<Order> CreateOrderAsync(Order order)
    {
        _logger.LogInformation("Saving order {OrderId} for user {UserId}", order.Id, order.UserId);
        // Simulate database save
        return order;
    }
}
