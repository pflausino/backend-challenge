using MediatR;

namespace SquareMetersValue.Domain.Notifications
{
    public class ErrorNotification
    {
        public class ErroNotification : INotification
        {
            public string Excecao { get; set; }
            public string PilhaErro { get; set; }
        }
    }
}
