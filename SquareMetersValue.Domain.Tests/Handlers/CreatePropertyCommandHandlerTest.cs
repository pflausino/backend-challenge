using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using AutoFixture;
using Moq;
using SquareMetersValue.Domain.Commands;
using SquareMetersValue.Domain.Enums;
using SquareMetersValue.Domain.Handlers;
using SquareMetersValue.Domain.Infra.Interfaces;
using SquareMetersValue.Domain.Models;
using Xunit;

namespace SquareMetersValue.Domain.Tests.Handlers
{
    public class CreatePropertyCommandHandlerTest
    {
        private readonly Fixture _fixture = new Fixture();


        [Fact]
        public async Task Handle_PassingInvalidCity_ReturnNotFoundError()
        {
            //Arrange
            var command = _fixture.Create<CreatePropertyCommand>();

            using var autoMock = AutoMock.GetLoose();

            var handler = autoMock.Create<CreatePropertyCommandHendler>();

            //Act
            var actual = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(actual.IsSuccess);
            Assert.Equal(ErrorType.NotFound, actual.Error.ErrorType);
        }

        [Fact]
        public async Task Handle_PassingValidParameters_ReturnSuccess()
        {
            //Arrange
            var command = _fixture.Create<CreatePropertyCommand>();
            var city = _fixture.Create<City>();

            using var autoMock = AutoMock.GetLoose();

            autoMock.Mock<ICitiesRepository>()
                .Setup(a => a.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(() => city);

            var handler = autoMock.Create<CreatePropertyCommandHendler>();

            //Act
            var actual = await handler.Handle(command, CancellationToken.None);


            //Assert
            Assert.True(actual.IsSuccess);

        }
    }
}
