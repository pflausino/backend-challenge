using SquareMetersValue.Domain.Infra.Interfaces;
using SquareMetersValue.Domain.Models;
using SquareMetersValue.Infra.Configurations;

namespace SquareMetersValue.Infra.Repositories
{
    public class CitiesRepository : Repository<City,City>, ICitiesRepository
    {
        public CitiesRepository(IMongoContext contex) : base(contex)
        {
        }
    }
}
