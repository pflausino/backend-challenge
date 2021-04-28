using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using SquareMetersValue.Domain.Core;
using SquareMetersValue.Domain.Infra.Interfaces;
using SquareMetersValue.Domain.Models;
using SquareMetersValue.Domain.Queries;
using SquareMetersValue.Domain.ViewModel;

namespace SquareMetersValue.Domain.Handlers
{
    public class CalculateSquareMeterAverageByCityQueryHandler
        : IRequestHandler<CalculateSquareMeterAverageByCityQuery,
            Result<RealStateStatisticDataViewModel, Error>>
    {
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly ICitiesRepository _citiesRepository;
        public CalculateSquareMeterAverageByCityQueryHandler(
            IPropertiesRepository propertiesRepository,
            ICitiesRepository citiesRepository)
        {
            _propertiesRepository = propertiesRepository;
            _citiesRepository = citiesRepository;
        }

        public async Task<Result<RealStateStatisticDataViewModel, Error>> Handle(
            CalculateSquareMeterAverageByCityQuery request,
            CancellationToken cancellationToken)
        {
            var city = await _citiesRepository.GetById(request.CityId);

            if (city == null)
                return Result.Failure<RealStateStatisticDataViewModel, Error>(
                    Error.NotFound(nameof(request.CityId), request.CityId));

            var properties = await _propertiesRepository.GetByCityId(request.CityId);
            //var properties = await _propertiesRepository.GetAll();

            if (!properties.Any())
                return Result.Failure<RealStateStatisticDataViewModel, Error>(
                    Error.NotFound(nameof(Property) + "By CityId", request.CityId));

            var statisticData = new Statistic(properties.ToList());

            var result = new RealStateStatisticDataViewModel(
                statisticData.TotalAccounted,
                statisticData.GetAverageDisplay(),
                statisticData.AveregePerSquareMeter,
                city.DisplayName);


            return Result.Success<RealStateStatisticDataViewModel, Error>(
                    result);
        }
    }
}
