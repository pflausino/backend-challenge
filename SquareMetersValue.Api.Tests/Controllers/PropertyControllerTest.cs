using System.Threading.Tasks;
using Autofac.Extras.Moq;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using SquareMetersValue.Api.Controllers;
using SquareMetersValue.Domain.Commands;
using Xunit;

namespace SquareMetersValue.Api.Tests.Controllers
{
    public class PropertyControllerTest
    {

        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public async Task Post_PassingInputData_ReturnNoContent()
        {
            //Arrange
            var command = _fixture.Create<CreatePropertyCommand>();

            using var autoMock = AutoMock.GetLoose();

            var controller = autoMock.Create<PropertiesController>();

            //Act
            var result = await controller.Post(command) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
