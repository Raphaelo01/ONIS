using Microsoft.Extensions.Logging;
using Moq;
using ONIS.Bussines.Catalog.Services;
using ONIS.Data.Catalog.Services.Interfaces;
using ONIS.Shared.Base.DTOs;
using ONIS.Shared.Base.DTOs.Interfaces;

namespace ONIS.Test.Catalog;

public class ProductServiceTests
{
    private readonly Mock<IProductCatalogRepository> _productRepositoryMock;
    private readonly Mock<ILogger<ProductService>> _loggerMock;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _productRepositoryMock = new Mock<IProductCatalogRepository>();
        _loggerMock = new Mock<ILogger<ProductService>>();
        _productService = new ProductService(_productRepositoryMock.Object, _loggerMock.Object);
    }
    //GetProduct
    [Fact]
    public async Task GetProductByIdAsync_WithValidId_ShouldReturnProductDto()
    {
        // Arrange
        int productId = 1;
        ProductDTO expectedProductDto = new Mock<ProductDTO>().Object;
        expectedProductDto.MaxStockThreshold = 10;
        expectedProductDto.RestockThreshold = 10;
        expectedProductDto.AvailableStock = 1;
        expectedProductDto.Description = "description";
        expectedProductDto.Price = 0;
        expectedProductDto.Name = "name";

        _productRepositoryMock.Setup(repo => repo.GetAsync(productId))
            .ReturnsAsync(expectedProductDto);


        // Act
        var result = await _productService.GetProductByIdAsync(productId);

        // Assert

        Assert.False(result.IsError);
        Assert.Equal(expectedProductDto, result.Result.FirstOrDefault());
        Assert.Equal(result.Message, string.Empty);

    }

    [Fact]
    public async Task GetProductByIdAsync_WithException_ShouldSetErrorAndLogError()
    {
        // Arrange
        int productId = 1;

        _productRepositoryMock.Setup(repo => repo.GetAsync(productId))
            .ThrowsAsync(new Exception("this is a exception"));

        // Act
        var result = await _productService.GetProductByIdAsync(productId);

        // Assert
        Assert.True(result.IsError);
        Assert.Null(result.Result);
        Assert.Equal("Error al obtener información", result.Message);

    }
    //End Get Product
    //Get Products
    [Fact]
    public async Task GetProductsAsync_ShouldReturnProductsDto()
    {
        // Arrange
        ProductDTO expectedProductDto1 = new Mock<ProductDTO>().Object;
        expectedProductDto1.MaxStockThreshold = 10;
        expectedProductDto1.RestockThreshold = 10;
        expectedProductDto1.AvailableStock = 1;
        expectedProductDto1.Description = "description2";
        expectedProductDto1.Price = 0;
        expectedProductDto1.Name = "name2";
        ProductDTO expectedProductDto2 = new Mock<ProductDTO>().Object;
        expectedProductDto2.MaxStockThreshold = 20;
        expectedProductDto2.RestockThreshold = 20;
        expectedProductDto2.AvailableStock = 2;
        expectedProductDto2.Description = "description2";
        expectedProductDto2.Price = 2;
        expectedProductDto2.Name = "name2";
        IEnumerable<ProductDTO> expectedProductsDto = new List<ProductDTO>()
        {
            expectedProductDto1,
            expectedProductDto2
        };

        // Arrange       

        _productRepositoryMock.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(expectedProductsDto);


        // Act
        var result = await _productService.GetProductsAsync();

        // Assert

        Assert.False(result.IsError);
        Assert.Equal(expectedProductsDto, result.Result);
        Assert.Equal(result.Message, string.Empty);

    }

    [Fact]
    public async Task GetProductsAsync_WithException_ShouldSetErrorAndLogError()
    {
        // Arrange
        _productRepositoryMock.Setup(repo => repo.GetAllAsync())
            .ThrowsAsync(new Exception("this is a exception"));

        // Act
        var result = await _productService.GetProductsAsync();

        // Assert
        Assert.True(result.IsError);
        Assert.Null(result.Result);
        Assert.Equal("Error al obtener información", result.Message);
    }
    //EndGet products
    //Starts Insert
    [Fact]
    public async Task InsertAsync_ShouldCallAddAndSaveChangesAsync()
    {
        // Arrange
        ProductDTO productDTO = new Mock<ProductDTO>().Object;
        productDTO.MaxStockThreshold = 10;
        productDTO.RestockThreshold = 10;
        productDTO.AvailableStock = 1;
        productDTO.Description = "description";
        productDTO.Price = 0;
        productDTO.Name = "name";

        var productRepositoryMock = new Mock<IProductCatalogRepository>();
        var loggerMock = new Mock<ILogger<ProductService>>();

        var productService = new ProductService(productRepositoryMock.Object, loggerMock.Object);

        // Act
        await productService.InsertAsync(productDTO);

        // Assert
        productRepositoryMock.Verify(repo => repo.Add(productDTO), Times.Once);
        productRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);

    }
    //End Insert
    //Stars Update 
    [Fact]
    public async Task UpdateProductAsync_ShouldCallUpdateAsyncAndSaveChangesAsync()
    {
        // Arrange
        int productId = 1;
        var productDTO = new Mock<IProductDTO>().Object;
        productDTO.MaxStockThreshold = 10;
        productDTO.RestockThreshold = 10;
        productDTO.AvailableStock = 1;
        productDTO.Description = "description";
        productDTO.Price = 0;
        productDTO.Name = "name";

        var productRepositoryMock = new Mock<IProductCatalogRepository>();
        var loggerMock = new Mock<ILogger<ProductService>>();


        var productService = new ProductService(productRepositoryMock.Object, loggerMock.Object);

        // Act
        await productService.UpdateProductAsync(productId, productDTO);

        // Assert
        productRepositoryMock.Verify(repo => repo.UpdateAsync(productId, productDTO), Times.Once);
        productRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);



    }
    //End Update
    //Starts Delete
    [Fact]
    public async Task DeleteProductAsync_ShouldCallDeleteAndSaveChangesAsync()
    {
        // Arrange
        int productId = 1;


        var productRepositoryMock = new Mock<IProductCatalogRepository>();
        var loggerMock = new Mock<ILogger<ProductService>>();

        var productService = new ProductService(productRepositoryMock.Object, loggerMock.Object);

        // Act
        await productService.DeleteProductAsync(productId);

        // Assert
        productRepositoryMock.Verify(repo => repo.Delete(productId), Times.Once);
        productRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
    }
    //End Delete
}
