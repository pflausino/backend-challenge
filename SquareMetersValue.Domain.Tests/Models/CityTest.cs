using System;
using SquareMetersValue.Domain.Entities;
using Xunit;

namespace SquareMetersValue.Domain.Tests.Entities
{
    public class CityTest
    {
        public CityTest()
        {
        }

        [Fact]
        public void Constructor_PassingValidParameters_CreateObject()
        {
            //Arrange
            var cityName = "Campinas";
            var cityState = "sp";
            var expectedDisplayName = "Campinas-SP";

            //Act
            var city = new City(cityName, cityState);
            city.Id = Guid.NewGuid();

            //Assert
            Assert.Equal(cityName, city.Name);
            Assert.Equal("SP", city.State);
            Assert.Equal(expectedDisplayName, city.DisplayName);
        }

    }
}
