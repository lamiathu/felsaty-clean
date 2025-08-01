﻿using MediatR;

namespace Sarfati.Core.Handlers
{
    public class ReachOutRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string Message { get; set; }
    }
}