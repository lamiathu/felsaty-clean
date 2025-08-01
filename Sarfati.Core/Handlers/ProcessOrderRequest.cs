using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class ProcessOrderRequest : IRequest
    {
        public string ParentId { get; set; }
        public string OrderId { get; set; }
    }
}