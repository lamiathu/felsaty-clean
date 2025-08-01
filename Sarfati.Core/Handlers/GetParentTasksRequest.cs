using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class GetParentTasksRequest : IRequest<GetParentTasksResponse>
    {
        public string ParentId { get; set; }
    }
}