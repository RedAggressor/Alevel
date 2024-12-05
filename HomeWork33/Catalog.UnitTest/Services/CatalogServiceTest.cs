using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.UnitTest.Services
{
    public class CatalogServiceTest
    {
        private readonly ICatalogService _serviceCatalog;

        private readonly Mock<ICatalogItemRepository> _catalogRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogService>> _logger;

        public CatalogServiceTest()
        {
            _catalogRepository = new Mock<ICatalogItemRepository>();
            _mapper = new Mock<IMapper>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _serviceCatalog = new CatalogService(_dbContextWrapper.Object, _logger.Object, _catalogRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetByPageAsync_Succusfull()
        {
            //arrage
            int pageSizeTest = 1;
            int pageIndexTest = 5;
            int totalCountTest = 12;

            var paginationItemReponceSeccusfull = new PaginatedItems<CatalogItem>()
            {
                TotalCount = totalCountTest,
                Data = new List<CatalogItem>()
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
                }
            };

            var catalogItemDtoSuccesfull = new CatalogItemDto()
            {
                Name = "Test"
                               
            };

            var catalogItemSuccesfull = new CatalogItem()
            {
                Name = "Test"
            };            

            _catalogRepository.Setup(s => s.GetByPageAsync(
                It.Is<int>(i => i == pageIndexTest),
                It.Is<int>(i => i == pageSizeTest)))
            .ReturnsAsync(paginationItemReponceSeccusfull);

            _mapper.Setup(s => s.Map<CatalogItemDto>(
                    It.Is<CatalogItem>(i => i.Equals(catalogItemSuccesfull))))
                .Returns(catalogItemDtoSuccesfull); // check mapper failed

            //act
            var reesponce = await _serviceCatalog.GetByPageAsync(pageSizeTest, pageIndexTest);

            //assert
            reesponce.Should().NotBeNull();
            reesponce.Count.Should().Be(totalCountTest);
            reesponce.Data.Should().NotBeNull();
            //reesponce.Data.First().Should().NotBeNull();
            reesponce.PageIndex.Should().Be(pageIndexTest);
            reesponce.PageSize.Should().Be(pageSizeTest);
        }

        [Fact]
        public async Task GetByPageAsync_Failed()
        {
            //arrage
            var pageIndexTest = 2000;
            var pageSizeTest = 1000;

            _catalogRepository.Setup(s => s.GetByPageAsync(
                It.Is<int>(i => i == pageIndexTest),
                It.Is<int>(i => i == pageSizeTest)))
            .Returns((Func<PaginatedItemsResponse<CatalogItemDto>>)null!);

            //act
            var responce = await _serviceCatalog.GetByPageAsync(pageSizeTest, pageIndexTest);

            //assert
            responce.Should().BeNull();
        }
    }
}
