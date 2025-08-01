using System;
using MediatR;
using Sarfati.Core.Enum;

namespace Sarfati.Core.Handlers
{
    public class CompleteTaskRequest : IRequest
    {
        public long TaskId { get; set; }
        public string UserId { get; set; }
        
        public string Image { get; set; }
    }
}