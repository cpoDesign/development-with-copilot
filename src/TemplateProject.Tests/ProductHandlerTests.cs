using Xunit;
using Moq;
using TemplateProject.Features.Products.GetProduct;
using TemplateProject.Infrastructure.Persistence;
using TemplateProject.Persistence;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace TemplateProject.Tests;

public class ProductHandlerTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly Mock<ICacheService> _mockCache;
    private readonly Mock<ILogger<GetProductHandler>> _mockLogger;
    private readonly GetProductHandler _handler;

    public ProductHandlerTests()
    {
        _mockRepo = new Mock<IProductRepository>();
        _mockCache = new Mock<ICacheService>();
        _mockLogger = new Mock<ILogger<GetProductHandler>>();
        _handler = new GetProductHandler(_mockRepo.Object, _mockCache.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task HandleAsync_ReturnsProduct_When_CacheMiss()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var product = new ProductDto(productId, "Test Product", 99.99m);
        _mockCache.Setup(c => c.Get<ProductDto>(It.IsAny<string>())).Returns((ProductDto)null);
        _mockRepo.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(new Product { Id = productId, Name = "Test Product", Price = 99.99m });

        // Act
        var result = await _handler.HandleAsync(new GetProductRequest(productId));

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Product", result.Name);
        _mockCache.Verify(c => c.Set(It.IsAny<string>(), It.IsAny<ProductDto>()), Times.Once);
    }

    [Fact]
    public async Task HandleAsync_ReturnsCachedProduct_When_CacheHit()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var cachedProduct = new ProductDto(productId, "Cached Product", 50.00m);
        _mockCache.Setup(c => c.Get<ProductDto>(It.IsAny<string>())).Returns(cachedProduct);

        // Act
        var result = await _handler.HandleAsync(new GetProductRequest(productId));

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Cached Product", result.Name);
        _mockRepo.Verify(r => r.GetByIdAsync(It.IsAny<Guid>()), Times.Never);
    }
}
