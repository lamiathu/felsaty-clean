using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class DeleteTaskRequest : IRequest<bool>
    {
        public long TaskId { get; set; }
        public string ParentId { get; set; }
    }
}