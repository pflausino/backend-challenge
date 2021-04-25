using System;
using System.Collections.Generic;
using System.Linq;
using SquareMetersValue.Domain.Models;
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
                new Property(100, (decimal)100000.00, city.Id, "Sobrado 2 Quartos"),
                new Property(50, (decimal)50000.00, city.Id, "Apartamento" ),
                new Property(75, (decimal)75000.00, city.Id, "Apartamento 3 Qt" ),
                new Property(200, (decimal)200000.00, city.Id, "Loja no Centro" ),

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
                new Property(100, (decimal)100000.00, city1.Id, "Sobrado 2 Quartos"),
                new Property(50, (decimal)50000.00, city2.Id, "Apartamento" ),
                new Property(75, (decimal)75000.00, city2.Id, "Apartamento 3 Qt" ),
                new Property(200, (decimal)200000.00, city2.Id, "Loja no Centro" ),

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
            Assert.True(realEstateStatisticData.Invalid);
            Assert.Single(realEstateStatisticData.ValidationResult.Errors);

        }


    }
}
