using System;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using SquareMetersValue.Domain.Core;

namespace SquareMetersValue.Infra.Mappings
{
    public class EntityMap
    {
        public static void Config()
        {
            BsonClassMap.RegisterClassMap<Entity>(map =>
            {
                map.SetIgnoreExtraElements(true);

                map.MapIdMember(c => c.Id).SetIdGenerator(CombGuidGenerator.Instance);
            });
        }
    }

}
