using System;
using System.ComponentModel.DataAnnotations;
using AutoFixture;
using AutoFixture.Xunit2;
using Xunit;
using SquareMetersValue.Domain.Entities;

namespace SquareMetersValue.Domain.Tests.Entities
{
    public class PropertyTest
    {

        public PropertyTest()
        {

        }

        [Theory, AutoData]
        public void Constructor_PassingRightParameters_CreatePropertyObject(
                [Range(1, 999999)] int size,
                [Range(0, 9999999999999999.99)] decimal propertyTotalValue


            )
        {
            //Arrange
            var description = "Apartamento 2 quartos";
            var city = new City("campinas", "sp");

            //Act
            var property = new Property(
                size,
                propertyTotalValue,
                city,
                description
            );

            //Assert
            Assert.Equal(size, property.Size);
            Assert.Equal(propertyTotalValue, property.TotalValue);
            Assert.Equal(description, property.Description);
            Assert.True(city.Equals(property.City));
        }

        [Fact]
        public void Constructor_PassingAllParameters_CalculateAveregePerSquareMeter()
        {
            //Arrange
            var city = new City("campinas", "sp");

            //Act
            var property = new Property(
                1000,
                5000000,
                city,
                "Chácara"
            );

            //Assert
            Assert.Equal(5000, property.AveregePerSquareMeter);
        }
        [Fact]
        public void Constructor_PassingASizeEqZero_AveregePerSquareMeterMustBeZero()
        { 
            //Arrange
            var city = new City("campinas", "sp");

            //Act
            var property = new Property(
                0,
                5000000,
                city,
                "Chácara"
            );

            //Assert
            Assert.Equal(0, property.AveregePerSquareMeter);
        }


    }
}
