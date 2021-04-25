using System;
using MediatR;
using SquareMetersValue.Domain.Models;

namespace SquareMetersValue.Domain.Notifications
{
    public class CreatePropertyNotification : INotification
    {
        public Guid Id { get; set; }
        public int Size { get; set; }
        public decimal TotalValue { get; set; }
        public City City { get; set; }
        public string Description { get; set; }
        public decimal AveregePerSquareMeter { get; set; }
 
    }
}
