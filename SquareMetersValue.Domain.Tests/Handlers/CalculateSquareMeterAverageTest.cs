using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using AutoFixture;
using Moq;
using SquareMetersValue.Domain.Enums;
using SquareMetersValue.Domain.Handlers;
using SquareMetersValue.Domain.Infra.Interfaces;
using SquareMetersValue.Domain.Models;
using SquareMetersValue.Domain.Queries;
using Xunit;

namespace SquareMetersValue.Domain.Tests.Handlers
{
    public class CalculateSquareMeterAverageTest
    {
        private readonly Fixture _fixture = new Fixture();


        [Fact]
        public async Task Handler_CityNotFound_ReturnNotFound()
        {
            //Arrange
            var query = _fixture.Create<CalculateSquareMeterAverageByCityQuery>();

            using var autoMock = AutoMock.GetLoose();

            var handler = autoMock.Create<CalculateSquareMeterAverageByCityQueryHandler>();

            //Act
            var actual = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.False(actual.IsSuccess);
            Assert.Equal(ErrorType.NotFound, actual.Error.ErrorType);
            Assert.Contains(nameof(query.CityId), actual.Error.Message);
        }

        [Fact]
        public async Task Handler_PassingCityWithNoProperties_ReturnNotFound()
        {
            //Arrange
            var query = _fixture.Create<CalculateSquareMeterAverageByCityQuery>();
            var city = _fixture.Create<City>();

            using var autoMock = AutoMock.GetLoose();
            autoMock.Mock<ICitiesRepository>()
                .Setup(a => a.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(() => city);


            var handler = autoMock.Create<CalculateSquareMeterAverageByCityQueryHandler>();

            //Act
            var actual = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.False(actual.IsSuccess);
            Assert.Equal(ErrorType.NotFound, actual.Error.ErrorType);
            Assert.Contains(nameof(Property), actual.Error.Message);

        }

        [Fact]
        public async Task Handler_PassingValidParams_ReturnStatisticData()
        {
            //Arrange
            var query = _fixture.Create<CalculateSquareMeterAverageByCityQuery>();
            var city = _fixture.Create<City>();
            var properties = new List<Property>{
                new Property(100,(decimal)1000000.00,city.Id,"Some description"),
                new Property(400,(decimal)400000.00,city.Id,"Some description2"),
                new Property(120,(decimal)130000.00,city.Id,"Some description3"),
                new Property(50,(decimal)1200000.00,city.Id,"Some description4"),

            };

            using var autoMock = AutoMock.GetLoose();

            autoMock.Mock<ICitiesRepository>()
                .Setup(a => a.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(() => city);

            autoMock.Mock<IPropertiesRepository>()
                .Setup(a => a.GetByCityId(It.IsAny<Guid>()))
                .ReturnsAsync(() => properties.AsQueryable());

            var handler = autoMock.Create<CalculateSquareMeterAverageByCityQueryHandler>();

            //Act
            var actual = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.True(actual.IsSuccess);
            Assert.Equal(properties.Count(), actual.Value.TotalProperties);

        }
    }
}
