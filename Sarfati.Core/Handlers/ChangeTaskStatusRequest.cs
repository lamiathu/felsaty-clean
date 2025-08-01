using System;
using MediatR;
using Sarfati.Core.Enum;

namespace Sarfati.Core.Handlers
{
    public class ChangeTaskStatusRequest : IRequest<Unit>
    {
        public Enums Status { get; set; }
        public long TaskId { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }
        public string Image { get; set; }
    }
}