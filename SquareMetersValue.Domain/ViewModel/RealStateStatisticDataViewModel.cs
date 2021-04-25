using System;
namespace SquareMetersValue.Domain.ViewModel
{
    public class RealStateStatisticDataViewModel
    {
        public RealStateStatisticDataViewModel(
            int totalProperties,
            decimal squareMeterAveragePrice,
            string cityName)
        {
            TotalProperties = totalProperties;
            SquareMeterAveragePrice = squareMeterAveragePrice;
            CityName = cityName;
        }

        public int TotalProperties { get; set; }
        public decimal SquareMeterAveragePrice { get; set; }
        public string CityName { get; set; }
    }
}
