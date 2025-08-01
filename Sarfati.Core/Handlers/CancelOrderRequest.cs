using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class CancelOrderRequest : IRequest
    {
        public string ParentId { get; set; }
        public string OrderId { get; set; }
    }
}