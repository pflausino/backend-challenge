namespace SquareMetersValue.Domain.ViewModel
{
    public class RealStateStatisticDataViewModel
    {
        public RealStateStatisticDataViewModel(
            int totalProperties,
            string squareMeterAveragePrice,
            decimal squareMeterAveragePriceValue,
            string cityName)
        {
            TotalProperties = totalProperties;
            SquareMeterAveragePrice = squareMeterAveragePrice;
            SquareMeterAveragePriceValue = squareMeterAveragePriceValue;
            CityName = cityName;
        }

        public int TotalProperties { get; set; }
        public string SquareMeterAveragePrice { get; set; }
        public decimal SquareMeterAveragePriceValue { get; set; }
        public string CityName { get; set; }
    }
}
