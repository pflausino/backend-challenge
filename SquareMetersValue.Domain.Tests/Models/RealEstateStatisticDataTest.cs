using System;
using System.Collections.Generic;
using SquareMetersValue.Domain.Entities;
using Xunit;

namespace SquareMetersValue.Domain.Tests.Entities
{
    public class RealEstateStatisticDataTest
    {
        public RealEstateStatisticDataTest()
        {

        }

        [Fact]
        public void Constructor_PassingAListOfProperty_CreateObject()
        {
            //Arrange
            var city = new City("campinas","sp");
            var properties = new List<Property>
            {
                new Property(100, (decimal)100000.00, city, "Sobrado 2 Quartos"),
                new Property(50, (decimal)50000.00, city, "Apartamento" ),
                new Property(75, (decimal)75000.00, city, "Apartamento 3 Qt" ),
                new Property(200, (decimal)200000.00, city, "Loja no Centro" ),

            };
            //Act
            var realEstateStatisticData = new RealEstateStatisticData(
                properties
            );
            //Assert
            Assert.Equal(properties.Count, realEstateStatisticData.TotalAccounted);
            Assert.Equal(
                (decimal)1000.00,
                realEstateStatisticData.AveregePerSquareMeter
            );
        }

        [Fact]
        public void Constructor_PassingDiffCities_MarkAsInvalidObject()
        {
            //Arrange
            var city1 = new City("campinas", "sp");
            city1.Id = Guid.NewGuid();
            var city2 = new City("Vinhedo", "sp");
            city2.Id = Guid.NewGuid();
            var properties = new List<Property>
            {
                new Property(100, (decimal)100000.00, city1, "Sobrado 2 Quartos"),
                new Property(50, (decimal)50000.00, city2, "Apartamento" ),
                new Property(75, (decimal)75000.00, city2, "Apartamento 3 Qt" ),
                new Property(200, (decimal)200000.00, city2, "Loja no Centro" ),

            };
            //Act
            var realEstateStatisticData = new RealEstateStatisticData(
                properties
            );
            //Assert
            Assert.Equal(
                0,
                realEstateStatisticData.AveregePerSquareMeter
            );

        }
    }
}
