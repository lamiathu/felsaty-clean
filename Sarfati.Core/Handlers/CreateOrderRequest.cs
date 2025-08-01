using System;
using System.Collections.Generic;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        public string ParentId { get; set; }
        
        public Dictionary<long, int> Products { get; set; }
        public decimal TotalAmount { get; set; }
        public string IdempotencyId { get; set; }
    }
}