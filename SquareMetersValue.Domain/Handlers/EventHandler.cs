using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SquareMetersValue.Domain.Notifications;

namespace SquareMetersValue.Domain.Handlers
{
    public class EventHandler :
        INotificationHandler<CreatePropertyNotification>
    {
        public Task Handle(
            CreatePropertyNotification notification,
            CancellationToken cancellationToken
        )
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} '");
            });
        }
    }
}
