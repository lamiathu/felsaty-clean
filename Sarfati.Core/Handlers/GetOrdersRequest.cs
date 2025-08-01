using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class GetOrdersRequest : IRequest<GetOrdersResponse>
    {
        public string ParentId { get; set; }
        public int PageNumber { get; set; }
        
        public int PageSize { get; set; } = 10;
    }
}