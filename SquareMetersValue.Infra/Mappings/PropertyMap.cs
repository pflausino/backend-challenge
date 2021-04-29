using System;
using MongoDB.Bson.Serialization;
using SquareMetersValue.Domain.Models;

namespace SquareMetersValue.Infra.Mappings
{
    public static class PropertyMap
    {
        public static void Config()
        {
            BsonClassMap.RegisterClassMap<Property>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.SetDiscriminator("property");

                map.MapCreator(p => new Property(
                    p.Size,
                    p.TotalValue,
                    p.CityId,
                    p.Description));

                map.MapMember(x => x.Size).SetDefaultValue(1);
                map.MapMember(x => x.TotalValue).SetDefaultValue(1);
                map.MapMember(x => x.CityId).SetDefaultValue(Guid.Empty);
                map.MapMember(x => x.Description).SetDefaultValue("");
                map.UnmapMember(m => m.AveragePerSquareMeter);
            });

        }
    }
}
