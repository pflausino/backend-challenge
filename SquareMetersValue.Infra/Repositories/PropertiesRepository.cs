using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SquareMetersValue.Domain.Infra.Interfaces;
using SquareMetersValue.Domain.Models;
using SquareMetersValue.Infra.Configurations;

namespace SquareMetersValue.Infra.Repositories
{
    public class PropertiesRepository : Repository<Property,Property>, IPropertiesRepository
    {
        public PropertiesRepository(IMongoContext contex) : base(contex) { }

        public async Task<IEnumerable<Property>> GetByCityId(Guid cityId)
        {
           
            var result = DbSet.AsQueryable()
                .Where(x => x.CityId == cityId);

            return result.ToList();
        }
    }
}

