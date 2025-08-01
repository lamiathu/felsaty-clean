using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class GetChildStatisticsRequest : IRequest<GetChildStatisticsResponse>
    {
        public string ChildId { get; set; }
    }
}