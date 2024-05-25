﻿using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Catalog.UnitTest.Services
{
    public class CatalogitemServiceTest
    {
        private readonly ICatalogItemService _catalogItemService;

        private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogItemService>> _logger;
        private readonly Mock<IMapper> _mapper;

        private readonly CatalogItem _testItem = new CatalogItem()
        {
            Name = "NameTest",
            Description = "DescriptionTest",
            Price = 1000,
            AvailableStock = 100,
            CatalogBrandId = 1,
            CatalogTypeId = 1,
            PictureFileName = "1.pngTest"
        };

        public CatalogitemServiceTest()
        {
            _catalogItemRepository = new Mock<ICatalogItemRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogItemService>>();
            _mapper = new Mock<IMapper>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogItemService = new CatalogItemService(_dbContextWrapper.Object, _logger.Object, _catalogItemRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task AddAsync_Seccusfull()
        {
            //arrage
            var testResult = 1;

            _catalogItemRepository
                .Setup(s => s.Add(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<decimal>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<string>()))
                .ReturnsAsync(testResult);

            //act
            var result = await _catalogItemService
                .Add(
                _testItem.Name,
                _testItem.Description,
                _testItem.Price,
                _testItem.AvailableStock,
                _testItem.CatalogBrandId,
                _testItem.CatalogTypeId,
                _testItem.PictureFileName
                );

            //asert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task AddAsync_Failed()
        {
            //arrage
            int? testResult = null;

            _catalogItemRepository
                .Setup(s => s.Add(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<decimal>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<string>()))
                .ReturnsAsync(testResult);

            //act
            var result = await _catalogItemService
                .Add(
                _testItem.Name,
                _testItem.Description,
                _testItem.Price,
                _testItem.AvailableStock,
                _testItem.CatalogBrandId,
                _testItem.CatalogTypeId,
                _testItem.PictureFileName
                );

            //asert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task GetCatalogItemsByIdAsync_Succesfull()
        {
            //arrage
            int id = 1;

            var catalogItemDtoSuccesfull = new CatalogItemDto()
            {
                Name = "Test",
                AvailableStock = 5,
                Description = "Test",
                Price = 10,
                PictureUrl = "Test",
                Id = 1
            };

            var catalogItemSuccesfull = new CatalogItem()
            {
                Name = "Test",
                AvailableStock = 5,
                Description = "Test",
                Price = 10,
                CatalogBrandId = 1,
                CatalogTypeId = 2,
                Id = 1
            };

            _catalogItemRepository
                .Setup(s => s.GetCatalogItemsByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(catalogItemSuccesfull);

            _mapper.Setup(s => s.Map<CatalogItemDto>(
                    It.Is<CatalogItem>(i => i.Equals(catalogItemSuccesfull))))
                .Returns(catalogItemDtoSuccesfull);

            //act
            var responce = await _catalogItemService.GetCatalogItemsByIdAsync(id);

            //asert
            responce.Should().NotBeNull();
            responce.Equals(catalogItemDtoSuccesfull);
        }

        [Fact]
        public async Task GetCatalogItemsByIdAsync_Failedl()
        {
            //arrage
            int? id = null;

            _catalogItemRepository
                .Setup(s => s.GetCatalogItemsByIdAsync(It.IsAny<int>()))
                .Returns((Func<CatalogItemDto>)null!);

            //act
            var responce = await _catalogItemService.GetCatalogItemsByIdAsync(id);

            //asert
            responce.Should().BeNull();
        }

        [Fact]
        public async Task Delete_Seccusfull()
        {
            //arrage
            int id = 1;

            var answer = "text";

            _catalogItemRepository
                .Setup(s => s.DeleteAsync(It.IsAny<int>()))
                .ReturnsAsync(answer);

            //act
            var reponce = await _catalogItemService.DeleteAsync(id);

            //asert
            reponce.Should().NotBeNull();
            reponce.Equals(answer);
        }

        [Fact]
        public async Task Delete_Failed()
        {
            //arrage
            int? id = null!;

            string? answer = "";

            _catalogItemRepository
                .Setup(s => s.DeleteAsync(It.IsAny<int>()))
                .ReturnsAsync(answer);

            //act
            var reponce = await _catalogItemService.DeleteAsync(id);

            //asert
            reponce.Should().NotBeNull();
            reponce.Equals(answer);
        }

        [Fact]
        public async Task Update_Succesfull()
        {
            //arrage
            var catalogItemDtoSuccesfull = new CatalogItemDto()
            {
                Name = "Test",
                AvailableStock = 5,
                Description = "Test",
                Price = 10,
                PictureUrl = "Test",
                Id = 1
            };

            var catalogItemSuccesfull = new CatalogItem()
            {
                Name = "Test",
                AvailableStock = 5,
                Description = "Test",
                Price = 10,
                CatalogBrandId = 1,
                CatalogTypeId = 2,
                Id = 1
            };

            _mapper
                .Setup(s => 
                    s.Map<CatalogItem>(It.Is<CatalogItemDto>(i => 
                        i.Equals(catalogItemDtoSuccesfull))))
                .Returns(catalogItemSuccesfull);

            _catalogItemRepository
                .Setup(s => s.Update(It.IsAny<CatalogItem>()))
                .ReturnsAsync(catalogItemSuccesfull);


            _mapper
                .Setup(s => 
                    s.Map<CatalogItemDto>(It.Is<CatalogItem>(i => 
                        i.Equals(catalogItemSuccesfull))))
                .Returns(catalogItemDtoSuccesfull);

            //act
            var reponce = await _catalogItemService
                .UpdateAsync(catalogItemDtoSuccesfull);

            //asert
            reponce.Should().NotBeNull();
            reponce.Description.Should().Be("Test");
        }

        [Fact]
        public async Task Update_Failed()
        {
            //arrage

            CatalogItemDto catalog = null;

            _catalogItemRepository
                .Setup(s => s.Update(It.IsAny<CatalogItem>()))
                .Returns((Func<CatalogItem>)null!);

            //act
            var reponce = await _catalogItemService.UpdateAsync(catalog);

            //asert
            reponce.Should().BeNull();
        }

        [Fact]
        public async Task GetCatalogItemByTypeAsync_Succesfull()
        {
            //arrage
            var id = 1;
            var list = new List<CatalogItem>()
            {
                new CatalogItem()
                {
                    Name ="Test",
                },
                new CatalogItem()
                {
                    Name ="Test",
                    AvailableStock = 5,
                    Description = "Test",
                    Price = 10,
                    CatalogBrandId = 1,
                    CatalogTypeId = 2,
                    PictureFileName = "Test"
                },
                new CatalogItem()
                {
                    Name ="Test",
                    AvailableStock = 5,
                    Description = "Test",
                    Price = 10,
                    CatalogBrandId = 1,
                    CatalogTypeId = 2,
                    PictureFileName = "Test"
                },
            };            

            var dto = new CatalogItemDto()
            {
                Name = "Test",
                AvailableStock = 5,
                Description = "Test",
                Price = 10,
                CatalogBrand = new CatalogBrandDto() { Brand = "test" },
                CatalogType = new CatalogTypeDto() { Type = "test" },

            };

            _mapper.Setup(s => s.Map<CatalogItemDto>(It.IsAny<CatalogItem>())).Returns(dto);

            _catalogItemRepository
                .Setup(s => s.GetCatalogItemsByTypeAsync(It.IsAny<int>()))
                .ReturnsAsync(list);

            //act
            var reponce = await _catalogItemService.GetCatalogItemByTypeAsync(id);

            //asert
            reponce.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCatalogItemByTypeAsync_Failed()
        {
            //arrage
            int? id = null;
            List<CatalogItem>? list = null;

            CatalogItemDto? dto = null;

            _mapper.Setup(s => s.Map<CatalogItemDto>(It.IsAny<CatalogItem>())).Returns(dto!);

            _catalogItemRepository
                .Setup(s => s.GetCatalogItemsByTypeAsync(It.IsAny<int>()))
                .ReturnsAsync(list!);

            //act
            var reponce = await _catalogItemService.GetCatalogItemByTypeAsync(id);

            //asert
            reponce.Should().BeNull();
        }

        [Fact]
        public async Task GetCatalogItemByandAsync_Succesfull()
        {
            //arrage
            var id = 1;
            var list = new List<CatalogItem>()
            {
                new CatalogItem()
                {
                    Name ="Test",
                },
                new CatalogItem()
                {
                    Name ="Test",                    
                },
                new CatalogItem()
                {
                    Name ="Test",                    
                },
            };

            var dto = new CatalogItemDto()
            {
                Name = "Test",
                AvailableStock = 5,
                Description = "Test",
                Price = 10,
                CatalogBrand = new CatalogBrandDto() { Brand = "test" },
                CatalogType = new CatalogTypeDto() { Type = "test" },

            };

            _mapper.Setup(s => s.Map<CatalogItemDto>(It.IsAny<CatalogItem>())).Returns(dto);

            _catalogItemRepository
                .Setup(s => s.GetCatalogItemsByBrandAsync(It.IsAny<int>()))
                .ReturnsAsync(list);

            //act
            var reponce = await _catalogItemService.GetCatalogItemByBrandAsync(id);

            //asert
            reponce.Should().NotBeNull();
        }
        [Fact]
        public async Task GetCatalogItemByBrandAsync_Failed()
        {
            //arrage
            int? id = null;
            List<CatalogItem>? list = null;

            CatalogItemDto? dto = null;

            _mapper.Setup(s => s.Map<CatalogItemDto>(It.IsAny<CatalogItem>())).Returns(dto!);

            _catalogItemRepository
                .Setup(s => s.GetCatalogItemsByBrandAsync(It.IsAny<int>()))
                .ReturnsAsync(list!);

            //act
            var reponce = await _catalogItemService.GetCatalogItemByBrandAsync(id);

            //asert
            reponce.Should().BeNull();
        }
    }
}
