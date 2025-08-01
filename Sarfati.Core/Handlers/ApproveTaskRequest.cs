using System;
using MediatR;
using Sarfati.Core.Enum;

namespace Sarfati.Core.Handlers
{
    public class ApproveTaskRequest : IRequest
    {
        public long TaskId { get; set; }
        public string UserId { get; set; }
    }
}