using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using SquareMetersValue.Infra.Mappings;

namespace SquareMetersValue.Infra.Configurations
{
    public static class MongoDbPersistence
    {
        public static void Configure()
        {



            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
            //BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));

            // Conventions

            var pack = new ConventionPack
            {
                new CamelCaseElementNameConvention(),
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };
            ConventionRegistry.Register("Conventions", pack, t => true);

            //Mappings
            CityMap.Config();
            PropertyMap.Config();
            EntityMap.Config();

        }
    }
}
