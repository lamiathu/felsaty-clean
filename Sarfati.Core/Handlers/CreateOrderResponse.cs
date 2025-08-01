using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class CreateOrderResponse
    {
        public Guid OrderId { get; set; }
    }
}