using Microsoft.Azure.Cosmos;
using System.Diagnostics;

namespace Infrastructure.CosmosDbAccess;

/// <summary>
/// Repository for managing Order data in Cosmos DB.
/// The AI will use this file to suggest indexes and evaluate RU costs.
/// </summary>
public class OrderRepository
{
    private readonly Container _container;

    public OrderRepository(CosmosClient client, string databaseId, string containerId)
    {
        _container = client.GetContainer(databaseId, containerId);
    }

    /// <summary>
    /// Fetches an order by ID and UserId.
    /// Query Analysis: Point read on ID and Partition Key.
    /// </summary>
    public async Task<OrderDto> GetOrderAsync(string orderId, string userId)
    {
        var response = await _container.ReadItemAsync<OrderDto>(orderId, new PartitionKey(userId));
        
        // Log RU and Performance
        LogCosmosTelemetry("GetOrder", orderId, response.RequestCharge, response.Diagnostics.ToString());
        
        return response.Resource;
    }

    /// <summary>
    /// Searches orders by Status and Date.
    /// Query Analysis: CROSS-PARTITION QUERY. Needs Indexing Policy for Status and Date.
    /// </summary>
    public async Task<List<OrderDto>> GetOrdersByStatusAsync(string status, DateTime startDate)
    {
        var query = new QueryDefinition("SELECT * FROM c WHERE c.Status = @status AND c.CreatedAt >= @start")
            .WithParameter("@status", status)
            .WithParameter("@start", startDate);

        using var iterator = _container.GetQueryIterator<OrderDto>(query);
        var results = new List<OrderDto>();
        
        while (iterator.HasMoreResults)
        {
            var page = await iterator.ReadNextAsync();
            foreach (var item in page)
            {
                results.Add(item);
            }
            // Note: RequestCharge must be logged per page
        }

        return results;
    }

    private void LogCosmosTelemetry(string operation, string id, double requestCharge, string diagnostics)
    {
        // Placeholder for actual logging framework (e.g., Serilog, Application Insights)
        Debug.WriteLine($"[CosmosTelemetry] Op: {operation}, ID: {id}, RU: {requestCharge}, Diag: {diagnostics}");
    }
}

public record OrderDto(string Id, string UserId, string Status, DateTime CreatedAt);
