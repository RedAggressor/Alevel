using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Infrastructure.Exeptions;
using Infrastructure.Models;


namespace Catalog.UnitTest.Services
{
    public class CatalogBrandServiceTest 
    {
        private readonly ICatalogBrandService _catalogBrandService;

        private readonly Mock<ICatalogBrandRepository> _brandRepository;
        private readonly Mock<ILogger<CatalogBrandService>> _Logger;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;        
        public CatalogBrandServiceTest() 
        {
            _brandRepository = new Mock<ICatalogBrandRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _mapper = new Mock<IMapper>();
            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(x => x.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);
            _Logger = new Mock<ILogger<CatalogBrandService>>();

            _catalogBrandService = new CatalogBrandService(_dbContextWrapper.Object, _Logger.Object, _brandRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task Add_Seccusfull()
        {
            //arrage
            var outTest = 1;
            string inTest = "test";

            _brandRepository
                .Setup(s => s.AddAsync(It.Is<string>(i => i == inTest)))
                .ReturnsAsync(outTest);

            //act
            var responce = await _catalogBrandService.AddAsync(inTest);

            //assert
            responce.Should().NotBeNull();
            responce.Id.Should().Be(outTest);
            responce.Id.Should().NotBeNull();
            responce.ErrorMessage.Should().BeNull();
            responce.RespCode.Should().BeNull();
        }

        [Fact]
        public async Task Add_Failed()
        {
            //arrage
            int? outTest = null;
            string? inTest = null;

            _brandRepository
                .Setup(s => s.AddAsync(It.IsAny<string>()))
                .ReturnsAsync(outTest);

            //act
            var responce = await _catalogBrandService.AddAsync(inTest);

            //assert
            responce.Should().NotBeNull();
            responce.Id.Should().BeNull();
            responce.ErrorMessage.Should().NotBeNull();
            responce.RespCode.Should().NotBeNull();
        }

        [Fact]
        public async Task Delete_Succesfull()
        {
            //arrage
            int inTest = 1;
            string? outTest = "test";

            _brandRepository
                .Setup(s=>s.DeleteAsync(It.IsAny<int>()))
                .ReturnsAsync(outTest);

            //act
            var responce = await _catalogBrandService.DeleteAsync(inTest);

            //assert
            responce.Should().NotBeNull();
            responce.ErrorMessage.Should().BeNull();
            responce.RespCode.Should().BeNull();
            responce.Status.Should().NotBeEmpty();
            responce.Status.Should().NotBeNull();
            responce.Status.Should().Be(outTest);
        }

        [Fact]
        public async Task Delete_Failed()
        {
            //arrage
            int? inTest = null;
            string? outTest = "test";

            _brandRepository
                .Setup(s => s.DeleteAsync(It.IsAny<int>()))
                .ReturnsAsync(outTest);

            //act
            var responce = await _catalogBrandService.DeleteAsync(inTest!);

            //assert
            responce.Should().NotBeNull();
            responce.ErrorMessage.Should().NotBeNull();
            responce.RespCode.Should().NotBeNull();
            responce.Status.Should().BeNull();
        }

        [Theory]
        [InlineData("test")]        
        public async Task Update_Succesfull(string input)
        {
            //arrage
            var dto = new CatalogBrandDto()
            { 
                Brand = input
            };

            var entity = new CatalogBrand() 
            { 
                Brand = input
            };

            _mapper
                .Setup(s => 
                    s.Map<CatalogBrand>(It.Is<CatalogBrandDto>(i => 
                        i.Equals(dto))))
                .Returns(entity);

            _brandRepository
                .Setup(s => 
                    s.UpdateAsync(It.Is<CatalogBrand>(s=>
                        s.Equals(entity))))
                .ReturnsAsync(entity);

            _mapper
                .Setup(s=>
                    s.Map<CatalogBrandDto>(It.Is<CatalogBrand>(i=>
                        i.Equals(entity))))
                .Returns(dto);

            //act
            var responce = await _catalogBrandService.UpdateAsync(dto);

            //assert
            responce.Should().NotBeNull();
            responce.ErrorMessage.Should().BeNull();
            responce.RespCode.Should().BeNull();
            responce.UpdataModel.Should().NotBeNull();
            responce.UpdataModel.Should().BeSameAs(dto);
        }
                
        [Fact]
        public async Task Update_Failed()
        {
            //arrage
            CatalogBrandDto? dto = null;

            CatalogBrand? entity = null;

            _mapper.Setup(s => 
                s.Map<CatalogBrand>(It.Is<CatalogBrandDto>(i => 
                    i.Equals(dto)))).Returns(entity!);

            _brandRepository
                .Setup(s => s.UpdateAsync(It.IsAny<CatalogBrand>()))
                .ReturnsAsync(entity);

            _mapper.Setup(s => 
                s.Map<CatalogBrandDto>(It.Is<CatalogBrand>(i => 
                    i.Equals(entity)))).Returns(dto!);

            //act
            var responce = await _catalogBrandService.UpdateAsync(dto);

            //assert
            responce.Should().NotBeNull();
            responce.ErrorMessage.Should().NotBeNull();
            responce.RespCode.Should().NotBeNull();
            responce.UpdataModel.Should().BeNull();
        }
    }
}
