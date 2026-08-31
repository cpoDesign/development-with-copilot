namespace TemplateProject.Domain;

public record OrderDto(string Id, string UserId, string Status, decimal Amount);

public class Order
{
    public string Id { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public string Status { get; set; } = default!;
    public decimal Amount { get; set; }
}
