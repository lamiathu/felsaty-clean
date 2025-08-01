using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class DeleteParentRequest : IRequest<bool>
    {
        public string Id { get; set; }
    }
}