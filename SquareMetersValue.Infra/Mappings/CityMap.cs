using MongoDB.Bson.Serialization;
using SquareMetersValue.Domain.Models;

namespace SquareMetersValue.Infra.Mappings
{
    public static class CityMap
    {
        public static void Config()
        {
            BsonClassMap.RegisterClassMap<City>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.SetDiscriminator("city");
                map.MapCreator(p => new City(p.Name,p.State));
            });
        }
    }
}
