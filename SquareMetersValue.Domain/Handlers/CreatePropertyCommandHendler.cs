using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using SquareMetersValue.Domain.Commands;
using SquareMetersValue.Domain.Core;
using SquareMetersValue.Domain.Infra.Interfaces;
using SquareMetersValue.Domain.Models;

namespace SquareMetersValue.Domain.Handlers
{
    public class CreatePropertyCommandHendler
        : IRequestHandler<CreatePropertyCommand, Result<Unit, Error>>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IMediator _mediator;
        private readonly ICitiesRepository _citiesRepository;
        private readonly IPropertiesRepository _propertiesRepository;


        public CreatePropertyCommandHendler(
            NotificationContext notificationContext,
            IMediator mediator,
            ICitiesRepository citiesRepository,
            IPropertiesRepository propertiesRepository)
        {
            _mediator = mediator;
            _citiesRepository = citiesRepository;
            _notificationContext = notificationContext;
            _propertiesRepository = propertiesRepository;
        }



        public async Task<Result<Unit, Error>> Handle(
            CreatePropertyCommand request,
            CancellationToken cancellationToken
        )
        {
            var city = await _citiesRepository.GetById(request.CityId);

            if (city == null)
            {
                _notificationContext.AddNotification(nameof(City), "Not Found");

                return Result.Failure<Unit, Error>(
                    Error.NotFound(nameof(City),
                    request.CityId)
                );
            }

            var property = new Property(
                request.Size,
                request.TotalValue,
                city.Id,
                request.Description
            );

            _propertiesRepository.Add(property);

            return Result.Success<Unit, Error>(Unit.Value);

        }
    }
}
