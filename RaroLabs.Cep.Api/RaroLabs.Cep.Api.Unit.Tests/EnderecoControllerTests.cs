using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RaroLabs.Cep.Api.Controllers;
using RaroLabs.Cep.Domain.Services;
using System.Threading.Tasks;
using Xunit;

namespace RaroLabs.Cep.Api.Unit.Tests
{
    public class EnderecoControllerTests
    {
        private static IMapper _mapper;

        public EnderecoControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public async Task Should_Return_Ok_When_Valid_Cep()
        {
            //Arrange
            var enderecoServiceMock = new Mock<IEnderecoService>();
            enderecoServiceMock.Setup(service => service.BuscarEndereco(It.IsAny<string>()));

            var controller = new EnderecoController(enderecoServiceMock.Object, _mapper);

            // Act
            var result = await controller.BuscarEndereco("93032370");

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Should_Return_BadRequest_When_Invalid_Cep()
        {
            //Arrange
            var enderecoServiceMock = new Mock<IEnderecoService>();
            enderecoServiceMock.Setup(service => service.BuscarEndereco(It.IsAny<string>()));

            var controller = new EnderecoController(enderecoServiceMock.Object, _mapper);

            // Act
            var result = await controller.BuscarEndereco("abccede-adsada");

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
