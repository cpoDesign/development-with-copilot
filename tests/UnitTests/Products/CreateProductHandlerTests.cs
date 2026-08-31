using TemplateProject.Features.Products.CreateProduct;
using TemplateProject.Persistence;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using System;
using System.Threading.Tasks;

namespace TemplateProject.Tests.UnitTests.Products;

public class CreateProductHandlerTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly Mock<ILogger<CreateProductHandler>> _mockLogger;
    private readonly CreateProductHandler _handler;

    public CreateProductHandlerTests()
    {
        _mockRepo = new Mock<IProductRepository>();
        _mockLogger = new Mock<ILogger<CreateProductHandler>>();
        _handler = new CreateProductHandler(_mockRepo.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task HandleAsync_ValidRequest_ReturnsGuid()
    {
        // Arrange
        var request = new CreateProductRequest("Test Product", "Description", 10.0m);

        // Act
        var result = await _handler.HandleAsync(request);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepo.Verify(x => x.AddAsync(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public async Task HandleAsync_InvalidName_ThrowsArgumentException()
    {
        // Arrange
        var request = new CreateProductRequest("", "Description", 10.0m);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _handler.HandleAsync(request));
    }
}
