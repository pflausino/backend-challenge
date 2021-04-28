using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquareMetersValue.Domain.Models;

namespace SquareMetersValue.Domain.Infra.Interfaces
{
    public interface IPropertiesRepository : IRepository<Property,Property>
    {
        Task<IEnumerable<Property>> GetByCityId(Guid cityId);

    }
}