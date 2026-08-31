using TemplateProject.Domain;
using TemplateProject.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace TemplateProject.Features.Orders.CreateOrder;

public record CreateOrderRequest(string UserId, decimal Amount);

public class CreateOrderHandler
{
    private readonly IOrderRepository _repository;
    private readonly ILogger<CreateOrderHandler> _logger;

    public CreateOrderHandler(IOrderRepository repository, ILogger<CreateOrderHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<OrderDto> HandleAsync(CreateOrderRequest request)
    {
        _logger.LogInformation("Handling create order for user {UserId}", request.UserId);
        
        var order = new Order 
        { 
            Id = Guid.NewGuid().ToString(), 
            UserId = request.UserId, 
            Status = "Pending", 
            Amount = request.Amount 
        };

        await _repository.CreateOrderAsync(order);
        
        return new OrderDto(order.Id, order.UserId, order.Status, order.Amount);
    }
}
