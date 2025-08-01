using System;
using MediatR;
using Sarfati.Core.Enum;

namespace Sarfati.Core.Handlers
{
    public class RejectTaskRequest : IRequest<bool>
    {
        public long TaskId { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }
        public string Notes { get; set; } = String.Empty;
    }
}