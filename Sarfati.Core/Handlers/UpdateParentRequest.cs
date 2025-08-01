using System;
using System.Collections.Generic;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class UpdateParentRequest : IRequest<bool>
    {
        public string Avatar { get; set; }
        public string ParentId { get; set; }
    }
}