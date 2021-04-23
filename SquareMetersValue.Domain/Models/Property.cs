namespace SquareMetersValue.Domain.Entities
{
    public class Property
    {
        public Property(int size, decimal totalValue, City city, string description)
        {
            Size = size;
            TotalValue = totalValue;
            City = city;
            Description = description;
            SetAveregePerSquareMeter();

        }
        public int Size { get; private set; }
        public decimal TotalValue { get; private set; }
        public City City { get; private set; }
        public string Description { get; private set; }
        public decimal AveregePerSquareMeter { get; private set; }

        public void SetAveregePerSquareMeter()
        {
            if(Size >= 1)
            {
                var averege = TotalValue / Size;

                AveregePerSquareMeter = averege;

            }
        }
    }
}
